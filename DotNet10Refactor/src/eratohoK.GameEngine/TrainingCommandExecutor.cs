namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// 調教コマンドエグゼキューター
/// 原版 ERB の各 <c>COM_{ID}()</c> 本体ロジックを統合した汎用実装。
/// アクションタイプ・キャラクター属性・天賦・装備・関係値に基づいて動的に数値を演算し、
/// SOURCE デルタを <see cref="TrainingSession"/> へ蓄積する。
///
/// 原版 ERB との対応:
/// <list type="bullet">
///   <item><see cref="TrainingActionType.Caress"/>     → COM_0xx 系（愛撫）</item>
///   <item><see cref="TrainingActionType.Oral"/>       → COM_1xx 系（口技）</item>
///   <item><see cref="TrainingActionType.Vaginal"/>    → COM_2xx 系（挿入）</item>
///   <item><see cref="TrainingActionType.Anal"/>       → COM_3xx 系（アナル）</item>
///   <item><see cref="TrainingActionType.Toy"/>        → COM_5xx 系（器具）</item>
///   <item><see cref="TrainingActionType.Mental"/>     → COM_6xx 系（精神調教）</item>
///   <item><see cref="TrainingActionType.Daily"/>      → COM_7xx 系（日常）</item>
///   <item><see cref="TrainingActionType.Punishment"/> → 制裁コマンド</item>
///   <item><see cref="TrainingActionType.Reward"/>     → 褒美コマンド</item>
/// </list>
/// </summary>
public sealed class TrainingCommandExecutor : ICommandExecutor
{
    private readonly Random _rng = Random.Shared;

    /// <inheritdoc/>
    public TrainingActionResult Execute(CommandContext context)
    {
        var trainer = context.Trainer;
        var target  = context.Target;
        var action  = context.Action;
        var config  = context.Config;

        // ── 1. ベース効果値をアクションタイプから算出 ──────────────────
        var (pleasureBase, obedienceBase, resistanceDelta, corruptionBase, sourceValues)
            = CalculateBaseEffects(action, config);

        // ── 2. 抵抗係数 (原版 ERB の反抗値による補正) ─────────────────
        double resistFactor = Math.Max(
            config.MinResistanceFactor,
            1.0 - target.BaseStatus.Resistance / config.MaxResistance);

        // ── 3. 好感度係数 (原版 LoveFactor) ──────────────────────────
        int like = trainer.GetLikeabilityTowards(target.Id);
        double loveFactor = 1.0 + Math.Clamp(like, config.MinLikeability, config.MaxLikeability)
                                  / config.LikeabilityScaleDivisor;

        // ── 4. 天賦補正 (TALENT フラグによる倍率調整) ─────────────────
        double pleasureMul    = action.PleasureMultiplier;
        double obedienceMul   = action.ObedienceMultiplier;
        double corruptionMul  = action.CorruptionMultiplier;

        ApplyTalentModifiers(target.Talent, action.ActionType, config,
            ref pleasureMul, ref obedienceMul);

        // ── 5. 最終演算 ────────────────────────────────────────────
        int pleasureChange   = (int)(pleasureBase  * resistFactor * loveFactor * pleasureMul);
        int obedienceChange  = (int)(obedienceBase * resistFactor * loveFactor * obedienceMul);
        int corruptionChange = (int)(corruptionBase * resistFactor * corruptionMul);

        var statChanges = new Dictionary<string, int>
        {
            ["Pleasure"]   = pleasureChange,
            ["Obedience"]  = obedienceChange,
            ["Resistance"] = resistanceDelta,
            ["Corruption"] = corruptionChange
        };

        // ── 6. キャラクターステータス更新 ──────────────────────────
        target.BaseStatus = target.BaseStatus with
        {
            Joy = Math.Clamp(
                target.BaseStatus.Joy + pleasureChange,
                config.MinStatValue, config.MaxStatValue),
            Obedience = Math.Clamp(
                target.BaseStatus.Obedience + obedienceChange,
                config.MinStatValue, config.MaxStatValue),
            Resistance = Math.Clamp(
                target.BaseStatus.Resistance + resistanceDelta,
                config.MinStatValue, config.MaxStatValue),
            Corruption = Math.Clamp(
                target.BaseStatus.Corruption + corruptionChange,
                config.MinStatValue, config.MaxStatValue)
        };

        // Experience counters
        target.Experience = action.ActionType switch {
            TrainingActionType.Vaginal => target.Experience with { Vaginal = target.Experience.Vaginal + 1 },
            TrainingActionType.Oral    => target.Experience with { Oral    = target.Experience.Oral    + 1 },
            TrainingActionType.Anal    => target.Experience with { Anal    = target.Experience.Anal    + 1 },
            TrainingActionType.Daily   => target.Experience with { Hand    = target.Experience.Hand    + 1 },
            _                          => target.Experience
        };

        // Virginity and First Time checks
        if (action.ActionType == TrainingActionType.Vaginal && target.Talent.IsVirgin)
        {
            var msg = ReactionSystem.GetFirstTimeReactionAsync(target, "処女喪失").GetAwaiter().GetResult();
            System.Console.WriteLine($"[{target.Name}] {msg}");
            target.Talent = target.Talent with { IsVirgin = false };
            statChanges["処女喪失"] = 1;
        }

        if (action.ActionType == TrainingActionType.Anal && target.Talent.IsAnalVirgin)
        {
            var msg = ReactionSystem.GetFirstTimeReactionAsync(target, "アナル初体験").GetAwaiter().GetResult();
            System.Console.WriteLine($"[{target.Name}] {msg}");
            target.Talent = target.Talent with { IsAnalVirgin = false };
            statChanges["アナル処女喪失"] = 1;
        }
        
        if (action.ActionType == TrainingActionType.Oral && target.Talent.IsKissInexperienced)
        {
            var msg = ReactionSystem.GetFirstTimeReactionAsync(target, "初キス").GetAwaiter().GetResult();
            System.Console.WriteLine($"[{target.Name}] {msg}");
            target.Talent = target.Talent with { IsKissInexperienced = false };
            statChanges["初キス"] = 1;
        }

        // Pregnancy check for Vaginal action
        if (action.ActionType == TrainingActionType.Vaginal && target.Gender == Gender.Female)
        {
            var pregnancyMsg = PregnancySystem.CheckConception(target, target.IsDangerDay, config.UseCondom, config, _rng);
            if (pregnancyMsg != null) statChanges["Pregnant"] = 1;
        }

        // Skill command passives
        SkillEngine.ProcessCommandPassives(trainer, target, action.ActionType, config);

        // ── 7. 体力消費 ────────────────────────────────────────────
        trainer.BaseStatus = trainer.BaseStatus with
        {
            Physical = Math.Max(0, trainer.BaseStatus.Physical - action.StaminaCost / 2)
        };
        target.BaseStatus = target.BaseStatus with
        {
            Physical = Math.Max(0, target.BaseStatus.Physical - action.StaminaCost)
        };

        // ── 8. SOURCE 値生成と蓄積 ─────────────────────────────────
        // 原版 ERB の COM_{ID}() 内 SOURCE_* 変数加算に対応
        var sourceDelta = BuildSourceDelta(action, pleasureChange, obedienceChange, like);
        context.Session.AccumulateSource(sourceDelta);

        // ── 9. セッション時間更新 ──────────────────────────────────
        context.Session.TimeUsed += action.TimeRequired;

        var result = new TrainingActionResult(
            action.Id, action.Name, true,
            $"{action.Name}を実行しました。",
            statChanges,
            sourceDelta);

        context.Session.Actions.Add(result);
        return result;
    }

    // ──────────────────────────────────────────────────────────────────────────
    // Private helpers
    // ──────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// アクションタイプに基づくベース効果値を算出する。
    /// 原版 ERB の各 COM_{ID} 内に散在していた固定値 / 乱数を一元管理。
    /// </summary>
    private (int pleasure, int obedience, int resistanceDelta, int corruption, SourceValues source)
        CalculateBaseEffects(TrainingActionDef action, GameConfig config)
    {
        // 乱数幅は原版 ERB 相当の半固定値（後から GameConfig に委譲可能）
        return action.ActionType switch
        {
            TrainingActionType.Caress => (
                pleasure:       5 + _rng.Next(10),
                obedience:      3 + _rng.Next(8),
                resistanceDelta: -(2 + _rng.Next(5)),
                corruption:     2 + _rng.Next(5),
                source: new SourceValues { Contact = 100, SexualActivity = 90, Service = 80 }
            ),
            TrainingActionType.Oral => (
                pleasure:       8 + _rng.Next(10),
                obedience:      4 + _rng.Next(8),
                resistanceDelta: -(3 + _rng.Next(5)),
                corruption:     3 + _rng.Next(6),
                source: new SourceValues { Contact = 100, SexualActivity = 150, Service = 100 }
            ),
            TrainingActionType.Vaginal => (
                pleasure:       10 + _rng.Next(10),
                obedience:      5 + _rng.Next(8),
                resistanceDelta: -(4 + _rng.Next(5)),
                corruption:     4 + _rng.Next(7),
                source: new SourceValues { Contact = 100, SexualActivity = 180 }
            ),
            TrainingActionType.Anal => (
                pleasure:       6 + _rng.Next(10),
                obedience:      4 + _rng.Next(8),
                resistanceDelta: -(2 + _rng.Next(5)),
                corruption:     5 + _rng.Next(8),
                source: new SourceValues { Contact = 100, SexualActivity = 180 }
            ),
            TrainingActionType.Toy => (
                pleasure:       7 + _rng.Next(10),
                obedience:      4 + _rng.Next(7),
                resistanceDelta: -(3 + _rng.Next(4)),
                corruption:     4 + _rng.Next(6),
                source: new SourceValues { Contact = 80, SexualActivity = 160 }
            ),
            TrainingActionType.Mental => (
                pleasure:       2 + _rng.Next(5),
                obedience:      8 + _rng.Next(8),
                resistanceDelta: -(5 + _rng.Next(5)),
                corruption:     3 + _rng.Next(5),
                source: new SourceValues { Humiliation = 80, Service = 60 }
            ),
            TrainingActionType.Daily => (
                pleasure:       1 + _rng.Next(4),
                obedience:      2 + _rng.Next(5),
                resistanceDelta: -(1 + _rng.Next(3)),
                corruption:     1 + _rng.Next(3),
                source: new SourceValues { Love = 30, Contact = 30 }
            ),
            TrainingActionType.Punishment => (
                pleasure:       -2 + _rng.Next(5),
                obedience:      3 + _rng.Next(8),
                resistanceDelta: -(6 + _rng.Next(5)),
                corruption:     2 + _rng.Next(5),
                source: new SourceValues { Pain = 120, Humiliation = 60 }
            ),
            TrainingActionType.Reward => (
                pleasure:       10 + _rng.Next(12),
                obedience:      5 + _rng.Next(8),
                resistanceDelta: -(1 + _rng.Next(4)),
                corruption:     1 + _rng.Next(3),
                source: new SourceValues { Love = 50, Pleasure = 60, Contact = 80 }
            ),
            _ => (
                pleasure:       5 + _rng.Next(10),
                obedience:      3 + _rng.Next(8),
                resistanceDelta: -(2 + _rng.Next(5)),
                corruption:     2 + _rng.Next(5),
                source: new SourceValues { Contact = 60, SexualActivity = 60 }
            )
        };
    }

    /// <summary>
    /// 対象の天賦フラグに基づき快感・服従倍率を調整する。
    /// 原版 ERB の各コマンド内 <c>IF TALENT:反抗的</c> 等に対応。
    /// </summary>
    private static void ApplyTalentModifiers(
        Talent talent,
        TrainingActionType actionType,
        GameConfig config,
        ref double pleasureMul,
        ref double obedienceMul)
    {
        // 反抗的：服従効果を抑制
        if (talent.IsRebellious)
            obedienceMul *= config.RebelliousPenaltyFactor;

        // 素直：服従効果を強化
        if (talent.IsHonest)
            obedienceMul *= config.HonestObedienceBonus;

        // 気丈：快感効果を低減（肉体コマンド限定）
        if (talent.IsStoic && actionType is
            TrainingActionType.Caress or TrainingActionType.Oral or
            TrainingActionType.Vaginal or TrainingActionType.Anal or TrainingActionType.Toy)
        {
            pleasureMul *= config.StoicPleasurePenalty;
        }

        // 濡れやすい：肉体快感ボーナス
        if (talent.IsEasilyWet && actionType is
            TrainingActionType.Caress or TrainingActionType.Oral or
            TrainingActionType.Vaginal or TrainingActionType.Anal)
        {
            pleasureMul *= config.EasilyWetBonus;
        }

        // 濡れにくい：肉体快感を低減
        if (talent.IsHardlyWet && actionType is
            TrainingActionType.Caress or TrainingActionType.Oral or
            TrainingActionType.Vaginal or TrainingActionType.Anal)
        {
            pleasureMul *= config.HardlyWetPenalty;
        }

        // 献身的：好感度が正の場合に服従ボーナス
        if (talent.IsDevoted)
            obedienceMul *= config.DevotedObedienceBonus;

        // 痛みに弱い：制裁コマンドの快感を増幅
        if (talent.IsWeakToPain && actionType == TrainingActionType.Punishment)
            pleasureMul *= config.WeakToPainBonus;

        // 痛みに強い：制裁コマンドの快感を低減
        if (talent.IsStrongToPain && actionType == TrainingActionType.Punishment)
            pleasureMul *= config.StrongToPainPenalty;
    }

    /// <summary>
    /// 実行結果から SOURCE デルタを生成する。
    /// 原版 ERB の COM_{ID}() 内 SOURCE_* 加算処理に対応。
    /// 好感度が正の場合は Love SOURCE を加算（爱情 SOURCE ボーナス）。
    /// </summary>
    private static SourceValues BuildSourceDelta(
        TrainingActionDef action,
        int pleasureChange,
        int obedienceChange,
        int likeability)
    {
        int loveBonus = likeability > 0 ? likeability / 2 : 0;

        return action.ActionType switch
        {
            TrainingActionType.Reward or TrainingActionType.Daily =>
                new SourceValues
                {
                    Love           = 50 + loveBonus,
                    Pleasure       = pleasureChange * 5,
                    Contact        = 40
                },
            TrainingActionType.Punishment =>
                new SourceValues
                {
                    Pain           = 100,
                    Humiliation    = obedienceChange * 5
                },
            TrainingActionType.Mental =>
                new SourceValues
                {
                    Humiliation    = obedienceChange * 6,
                    Love           = loveBonus
                },
            _ =>
                new SourceValues
                {
                    Pleasure       = pleasureChange  * 8,
                    Love           = loveBonus,
                    SexualActivity = pleasureChange  * 3
                }
        };
    }
}
