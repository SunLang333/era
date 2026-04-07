namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// 戦闘エンジン
/// 勢力間の攻城戦・野戦を解決する。
/// 原版 ERA の簡易戦闘ロジックを参考にした確率ベース実装。
/// </summary>
public class BattleEngine
{
    private readonly Random _rng = Random.Shared;

    // ── 定数 ──────────────────────────────────────────────────────────
    private const double AttackRollMin    = 0.6;
    private const double AttackRollMax    = 1.4;
    private const double DefenseRollMin   = 0.5;
    private const double DefenseRollMax   = 1.5;
    private const double AttackerLossPct  = 0.15;
    private const double DefenderLossPct  = 0.12;
    private const int    PlunderGoldRate  = 5;
    private const int    MinSoldierAfter  = 0;

    /// <summary>
    /// 攻城戦を解決する。
    /// 攻撃側が勝利した場合、都市の帰属が攻撃側に変更される。
    /// </summary>
    /// <param name="attacker">攻撃勢力</param>
    /// <param name="defender">防衛勢力</param>
    /// <param name="targetCity">攻撃対象の都市</param>
    /// <returns>戦闘結果</returns>
    public BattleResult ResolveSiege(Country attacker, Country defender, City targetCity)
    {
        double attackRoll = attacker.SoldierCount
            * (_rng.NextDouble() * (AttackRollMax - AttackRollMin) + AttackRollMin);
        double defenseRoll = defender.SoldierCount
            * (_rng.NextDouble() * (DefenseRollMax - DefenseRollMin) + DefenseRollMin)
            + targetCity.Defense;

        bool attackerWins = attackRoll > defenseRoll;

        int attackerLoss = (int)(attacker.SoldierCount * AttackerLossPct
            + defenseRoll * 0.04);
        int defenderLoss = (int)(defender.SoldierCount * DefenderLossPct
            + attackRoll * 0.05);

        attackerLoss = Math.Clamp(attackerLoss, 1, attacker.SoldierCount);
        defenderLoss = Math.Clamp(defenderLoss, 0, defender.SoldierCount);

        attacker.SoldierCount = Math.Max(MinSoldierAfter, attacker.SoldierCount - attackerLoss);
        defender.SoldierCount = Math.Max(MinSoldierAfter, defender.SoldierCount - defenderLoss);

        int plunder = 0;
        if (attackerWins)
        {
            var oldCountryId = targetCity.CountryId;
            targetCity.CountryId = attacker.Id;
            if (!attacker.CityIds.Contains(targetCity.Id))
                attacker.CityIds.Add(targetCity.Id);
            defender.CityIds.Remove(targetCity.Id);

            // 都市の金を一部略奪
            plunder = targetCity.Gold / 4;
            targetCity.Gold -= plunder;

            // 防衛側に他の都市がなければ滅亡
            if (defender.CityIds.Count == 0)
                defender.IsDestroyed = true;
        }

        return new BattleResult(
            AttackerWon: attackerWins,
            AttackerName: attacker.Name,
            DefenderName: defender.Name,
            CityName: targetCity.Name,
            AttackerLoss: attackerLoss,
            DefenderLoss: defenderLoss,
            Plunder: plunder,
            DefenderDestroyed: defender.IsDestroyed);
    }

    /// <summary>
    /// 野戦（都市なし、野外での激突）を解決する。
    /// 勝者の決定のみを行い、都市帰属は変化しない。
    /// </summary>
    public FieldBattleResult ResolveFieldBattle(Country attacker, Country defender)
    {
        double aRoll = attacker.SoldierCount
            * (_rng.NextDouble() * (AttackRollMax - AttackRollMin) + AttackRollMin);
        double dRoll = defender.SoldierCount
            * (_rng.NextDouble() * (DefenseRollMax - DefenseRollMin) + DefenseRollMin);

        bool attackerWins = aRoll > dRoll;

        int aLoss = (int)(attacker.SoldierCount * 0.08 + dRoll * 0.03);
        int dLoss = (int)(defender.SoldierCount * 0.08 + aRoll * 0.04);

        attacker.SoldierCount = Math.Max(0, attacker.SoldierCount - aLoss);
        defender.SoldierCount = Math.Max(0, defender.SoldierCount - dLoss);

        return new FieldBattleResult(attackerWins, attacker.Name, defender.Name, aLoss, dLoss);
    }
}

/// <summary>攻城戦結果</summary>
public record BattleResult(
    bool AttackerWon,
    string AttackerName,
    string DefenderName,
    string CityName,
    int AttackerLoss,
    int DefenderLoss,
    int Plunder,
    bool DefenderDestroyed);

/// <summary>野戦結果</summary>
public record FieldBattleResult(
    bool AttackerWon,
    string AttackerName,
    string DefenderName,
    int AttackerLoss,
    int DefenderLoss);
