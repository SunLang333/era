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
    /// 攻城戦を解決する（後方互換オーバーロード）。
    /// </summary>
    public BattleResult ResolveSiege(Country attacker, Country defender, City targetCity)
        => ResolveSiege(attacker, defender, targetCity, null, null);

    /// <summary>
    /// 攻城戦を解決する（指揮官指定・ラウンドログ付き版）。
    /// 攻撃側が勝利した場合、都市の帰属が攻撃側に変更される。
    /// </summary>
    public BattleResult ResolveSiege(Country attacker, Country defender, City targetCity,
        IEnumerable<Character>? attackerCommanders,
        IEnumerable<Character>? defenderCommanders)
    {
        var atkCmdrs = attackerCommanders?.ToList() ?? [];
        var defCmdrs = defenderCommanders?.ToList() ?? [];
        bool hasCombatDoctrine = attacker.HasTechnology("CombatDoctrine");
        double techBonus = defCmdrs.Count > 0 ? 0.1 : 0.0;

        var roundLog = new List<string>();
        int atkWins = 0, defWins = 0;
        int totalAtkLoss = 0, totalDefLoss = 0;
        int rounds = 0;
        const int MaxRounds = 5;

        while (rounds < MaxRounds && atkWins < 3 && defWins < 3
               && attacker.SoldierCount > 0 && defender.SoldierCount > 0)
        {
            rounds++;
            double cmdBonus = atkCmdrs.Sum(c => c.Ability.Command / 10.0 + c.Ability.Fight / 20.0);
            double attackRoll = (attacker.SoldierCount * (_rng.NextDouble() * 0.6 + 0.7)) * (1.0 + cmdBonus / 100.0);
            if (hasCombatDoctrine) attackRoll *= 1.2;
            double defenseRoll = (defender.SoldierCount * (_rng.NextDouble() * 0.6 + 0.7)) + targetCity.Defense * (1.0 + techBonus);

            bool roundWin = attackRoll > defenseRoll;
            if (roundWin) atkWins++; else defWins++;

            int atkLoss = (int)(attacker.SoldierCount * 0.08 + defenseRoll * 0.02);
            int defLoss = (int)(defender.SoldierCount * 0.07 + attackRoll  * 0.02);
            atkLoss = Math.Clamp(atkLoss, 1, attacker.SoldierCount);
            defLoss = Math.Clamp(defLoss, 0, defender.SoldierCount);
            attacker.SoldierCount = Math.Max(0, attacker.SoldierCount - atkLoss);
            defender.SoldierCount = Math.Max(0, defender.SoldierCount - defLoss);
            totalAtkLoss += atkLoss; totalDefLoss += defLoss;

            roundLog.Add($"  ラウンド{rounds}: {(roundWin ? "攻撃側優勢" : "防衛側優勢")} | 損失 攻:{atkLoss} 防:{defLoss}");
        }

        bool attackerWins = atkWins > defWins;
        int plunder = 0;
        int? capturedCharId = null;

        if (attackerWins)
        {
            targetCity.CountryId = attacker.Id;
            if (!attacker.CityIds.Contains(targetCity.Id)) attacker.CityIds.Add(targetCity.Id);
            defender.CityIds.Remove(targetCity.Id);
            plunder = targetCity.Gold / 4;
            targetCity.Gold -= plunder;
            if (defender.CityIds.Count == 0) defender.IsDestroyed = true;
            // 30% chance to capture defender's boss
            if (_rng.NextDouble() < 0.3 && defender.BossCharacterId > 0)
                capturedCharId = defender.BossCharacterId;
        }

        return new BattleResult(attackerWins, attacker.Name, defender.Name, targetCity.Name,
            totalAtkLoss, totalDefLoss, plunder, defender.IsDestroyed, rounds, roundLog, capturedCharId);
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
    bool DefenderDestroyed,
    int RoundsPlayed = 1,
    List<string>? RoundLog = null,
    int? CapturedCharacterId = null);

/// <summary>野戦結果</summary>
public record FieldBattleResult(
    bool AttackerWon,
    string AttackerName,
    string DefenderName,
    int AttackerLoss,
    int DefenderLoss);
