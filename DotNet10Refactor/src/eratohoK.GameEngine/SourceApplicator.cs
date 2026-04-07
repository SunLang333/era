namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// 標準 SOURCE 適用サービス
/// 原版 ERB の <c>APPLY_SOURCE()</c> 関数に対応。
/// セッション終了後に蓄積された SOURCE 値をキャラクターステータスへ変換する。
///
/// 変換ルール:
/// <list type="bullet">
///   <item>Pleasure → Joy / Corruption 増加</item>
///   <item>Love    → Likeability 増加</item>
///   <item>Humiliation → Humiliation / Obedience 増加</item>
///   <item>Pain    → Fear / Resistance 増加</item>
/// </list>
/// </summary>
public sealed class SourceApplicator : ISourceAccumulator
{
    /// <inheritdoc/>
    public IDictionary<string, int> ApplySource(SourceValues source, Character target, int trainerId, GameConfig config)
    {
        var changes = new Dictionary<string, int>();

        // 快感系 → 愉悦・堕落
        if (source.Pleasure != 0)
        {
            int joyDelta        = source.Pleasure / 10;
            int corruptionDelta = source.Pleasure / 20;

            int newJoy = Math.Clamp(
                target.BaseStatus.Joy + joyDelta,
                config.MinStatValue, config.MaxStatValue);
            int newCorruption = Math.Clamp(
                target.BaseStatus.Corruption + corruptionDelta,
                config.MinStatValue, config.MaxStatValue);

            changes["Joy"]        = newJoy        - target.BaseStatus.Joy;
            changes["Corruption"] = newCorruption - target.BaseStatus.Corruption;

            target.BaseStatus = target.BaseStatus with
            {
                Joy        = newJoy,
                Corruption = newCorruption
            };
        }

        // 爱情系 → 対トレーナー好感度
        if (source.Love != 0)
        {
            int loveDelta = source.Love / 10;
            target.UpdateLikeability(trainerId, loveDelta);
            changes["Likeability"] = loveDelta;
        }

        // 屈辱系 → 屈辱・服従
        if (source.Humiliation != 0)
        {
            int humDelta       = source.Humiliation / 10;
            int obedDelta      = source.Humiliation / 15;

            int newHum = Math.Clamp(
                target.BaseStatus.Humiliation + humDelta,
                config.MinStatValue, config.MaxStatValue);
            int newObed = Math.Clamp(
                target.BaseStatus.Obedience + obedDelta,
                config.MinStatValue, config.MaxStatValue);

            changes["Humiliation"] = newHum  - target.BaseStatus.Humiliation;
            changes["Obedience"]   = newObed - target.BaseStatus.Obedience;

            target.BaseStatus = target.BaseStatus with
            {
                Humiliation = newHum,
                Obedience   = newObed
            };
        }

        // 痛苦系 → 恐怖・反抗
        if (source.Pain != 0)
        {
            int fearDelta       = source.Pain / 10;
            int resistanceDelta = source.Pain / 8;

            int newFear = Math.Clamp(
                target.BaseStatus.Fear + fearDelta,
                config.MinStatValue, config.MaxStatValue);
            int newResistance = Math.Clamp(
                target.BaseStatus.Resistance + resistanceDelta,
                config.MinStatValue, config.MaxStatValue);

            changes["Fear"]       = newFear       - target.BaseStatus.Fear;
            changes["Resistance"] = newResistance - target.BaseStatus.Resistance;

            target.BaseStatus = target.BaseStatus with
            {
                Fear       = newFear,
                Resistance = newResistance
            };
        }

        return changes;
    }
}
