namespace eratohoK.GameEngine;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using eratohoK.Core;

public static class SemanticPromptBuilder
{
    public static string BuildReactionPrompt(DialogueSemanticEvent semanticEvent)
    {
        var sb = new StringBuilder();
        bool isSelfFocusedEvent = semanticEvent.Subject.Id == semanticEvent.Target.Id
            && semanticEvent.Subject.Name == semanticEvent.Target.Name;

        sb.AppendLine("请不要返回多余的内容，只返回该角色面对当前事件的第一人称短台词、或夹杂极短的第三人称动作描写。保持简短。");
        sb.AppendLine("【输出规则】");
        sb.AppendLine($"- 说话者必须是受动者「{semanticEvent.Target.Name}」，默认使用第一人称。");
        if (!isSelfFocusedEvent)
        {
            sb.AppendLine($"- 把施动者「{semanticEvent.Subject.Name}」视为对方，不要把「{semanticEvent.Target.Name}」写成主动执行本次动作的人。");
        }
        sb.AppendLine("- 不要输出角色姓名开头的小说式长旁白，不要把角色写成在抚摸自己或对自己施加当前动作。");
        sb.AppendLine("- 允许先在<think>...</think>里进行内部思考。最终台词不要夹带规则解释、系统说明或长篇分析。");
        sb.AppendLine("【当前情境】");
        sb.AppendLine($"- 行动名：{semanticEvent.ActionName}");
        if (isSelfFocusedEvent)
        {
            sb.AppendLine($"- 事件主体：{semanticEvent.Target.Name}");
        }
        else
        {
            sb.AppendLine($"- 施动者：{semanticEvent.Subject.Name}");
            sb.AppendLine($"- 受动者：{semanticEvent.Target.Name}");
        }
        sb.AppendLine($"- 谓语：{semanticEvent.Verb}");
        if (!string.IsNullOrWhiteSpace(semanticEvent.ObjectLabel))
        {
            sb.AppendLine($"- 宾语：{semanticEvent.ObjectLabel}");
        }

        if (!string.IsNullOrWhiteSpace(semanticEvent.SceneContext))
        {
            sb.AppendLine($"- 场景补充：{semanticEvent.SceneContext}");
        }

        if (semanticEvent.Modifiers is { Count: > 0 })
        {
            sb.AppendLine($"- 语义修饰：{string.Join("；", semanticEvent.Modifiers)}");
        }

        if (semanticEvent.StatDelta is not null)
        {
            sb.AppendLine($"- 数值变化：快感{FormatSigned(semanticEvent.StatDelta.Joy)}，服从{FormatSigned(semanticEvent.StatDelta.Obedience)}，反抗{FormatSigned(semanticEvent.StatDelta.Resistance)}，堕落{FormatSigned(semanticEvent.StatDelta.Corruption)}，体力{FormatSigned(semanticEvent.StatDelta.Physical)}");
        }

        sb.AppendLine();
        AppendCharacterProfile(
            sb,
            semanticEvent.Target.Name,
            semanticEvent.Target.Talent,
            semanticEvent.Target.Experience,
            semanticEvent.Target.BaseStatus,
            semanticEvent.Target.IsInLove,
            semanticEvent.Target.IsLover,
            semanticEvent.Target.IsPregnant);

        if (!string.IsNullOrWhiteSpace(semanticEvent.AdditionalRules))
        {
            sb.AppendLine("【附加演出版规则】");
            sb.AppendLine(semanticEvent.AdditionalRules);
        }

        AppendThinkFormatHint(sb);
        return sb.ToString();
    }

    public static string BuildReactionPrompt(Character character, string actionName, string eventContext, string additionalRules = "")
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("请不要返回多余的内容，只返回该角色面对当前事件的第一人称台词、或夹杂简短的第三人称动作描写/旁白。");
        sb.AppendLine("【输出规则】");
        sb.AppendLine($"- 说话者必须是「{character.Name}」，默认使用第一人称。");
        sb.AppendLine("- 允许先在<think>...</think>里进行内部思考。最终台词不要夹带规则解释、系统说明或长篇分析。");
        sb.AppendLine("- 不要写成长篇第三人称旁白，也不要让角色像旁观者一样解说自己。");
        sb.AppendLine("【当前情境】");
        sb.AppendLine($"- 发生的事件：{actionName}");
        if (!string.IsNullOrEmpty(eventContext))
        {
            sb.AppendLine($"- 事件补充细节：{eventContext}");
        }
        
        sb.AppendLine();
        AppendCharacterProfile(
            sb,
            character.Name,
            character.Talent,
            character.Experience,
            character.BaseStatus,
            character.IsInLove,
            character.IsLover,
            character.IsPregnant);

        if (!string.IsNullOrEmpty(additionalRules))
        {
            sb.AppendLine("【附加演出版规则】");
            sb.AppendLine(additionalRules);
        }
        
        AppendThinkFormatHint(sb);
        return sb.ToString();
    }

    private static void AppendCharacterProfile(
        StringBuilder sb,
        string name,
        Talent talent,
        Experience experience,
        BaseStatus baseStatus,
        bool isInLove,
        bool isLover,
        bool isPregnant)
    {
        sb.AppendLine("【角色设定档案】");
        sb.AppendLine($"- 姓名：{name}");

        var tags = BuildPersonalityTags(talent);
        if (tags.Count > 0)
        {
            sb.AppendLine($"- 性格核心标签：{string.Join(", ", tags)}");
        }

        var statusTags = BuildStatusTags(talent, experience, isInLove, isLover, isPregnant);
        if (statusTags.Count > 0)
        {
            sb.AppendLine($"- 当前状态：{string.Join(", ", statusTags)}");
        }

        sb.AppendLine($"- 服从度：{baseStatus.Obedience} (数值越高越顺从)");
        sb.AppendLine($"- 反抗刻印：{baseStatus.Resistance} (数值越高反抗情绪越重)");
        sb.AppendLine($"- 愉悦：{baseStatus.Joy} (数值越高身体反应越明显)");
    }

    private static List<string> BuildPersonalityTags(Talent talent)
    {
        var tags = new List<string>();
        if (talent.IsTsundere) tags.Add("傲娇(ツンデレ)");
        if (talent.IsShy) tags.Add("易害羞(恥じらい)");
        if (talent.IsShameless) tags.Add("不知羞耻(恥薄い)");
        if (talent.IsProud) tags.Add("高傲(プライド高い)");
        if (talent.IsLowPride) tags.Add("自卑(プライド低い)");
        if (talent.IsCowardly) tags.Add("胆小(臆病)");
        if (talent.IsRebellious) tags.Add("叛逆(反抗的)");
        if (talent.IsHonest) tags.Add("坦率(素直)");
        if (talent.IsOptimistic) tags.Add("乐观(楽観的)");
        if (talent.IsPessimistic) tags.Add("悲观(悲観的)");
        return tags;
    }

    private static List<string> BuildStatusTags(
        Talent talent,
        Experience experience,
        bool isInLove,
        bool isLover,
        bool isPregnant)
    {
        var statusTags = new List<string>();
        if (isInLove) statusTags.Add("已进入恋慕状态（深深爱着主角）");
        else if (isLover) statusTags.Add("已经是恋人");
        if (isPregnant) statusTags.Add("已怀孕");
        if (talent.IsVirgin) statusTags.Add("处女");
        else statusTags.Add($"已有本番经验 ({experience.Vaginal}次)");
        if (talent.IsAnalVirgin) statusTags.Add("后庭处女");
        return statusTags;
    }

    private static void AppendThinkFormatHint(StringBuilder sb)
    {
        sb.AppendLine();
        sb.AppendLine(" ");
        sb.Append(" ");
    }

    private static string FormatSigned(int value) => value >= 0 ? $"+{value}" : value.ToString();
}