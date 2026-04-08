namespace eratohoK.GameEngine;

using System.Linq;
using System.Text;
using eratohoK.Core;

public static class SemanticPromptBuilder
{
    public static string BuildReactionPrompt(Character character, string actionName, string eventContext, string additionalRules = "")
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("请不要返回多余的内容，只返回该角色面对当前事件的第一人称台词、或夹杂简短的第三人称动作描写/旁白。保持简短。");
        sb.AppendLine("【当前情境】");
        sb.AppendLine($"- 发生的事件：{actionName}");
        if (!string.IsNullOrEmpty(eventContext))
        {
            sb.AppendLine($"- 事件补充细节：{eventContext}");
        }
        
        sb.AppendLine();
        sb.AppendLine("【角色设定档案】");
        sb.AppendLine($"- 姓名：{character.Name}");
        
        // Tags
        var tags = new System.Collections.Generic.List<string>();
        var t = character.Talent;
        if (t.IsTsundere) tags.Add("傲娇(ツンデレ)");
        if (t.IsShy) tags.Add("易害羞(恥じらい)");
        if (t.IsShameless) tags.Add("不知羞耻(恥薄い)");
        if (t.IsProud) tags.Add("高傲(プライド高い)");
        if (t.IsLowPride) tags.Add("自卑(プライド低い)");
        if (t.IsCowardly) tags.Add("胆小(臆病)");
        if (t.IsRebellious) tags.Add("叛逆(反抗的)");
        if (t.IsHonest) tags.Add("坦率(素直)");
        if (t.IsOptimistic) tags.Add("乐观(楽観的)");
        if (t.IsPessimistic) tags.Add("悲观(悲観的)");
        
        if (tags.Any())
        {
            sb.AppendLine($"- 性格核心标签：{string.Join(", ", tags)}");
        }
        
        // Status Tags
        var statusTags = new System.Collections.Generic.List<string>();
        if (character.IsInLove) statusTags.Add("已进入恋慕状态（深深爱着主角）");
        else if (character.IsLover) statusTags.Add("已经是恋人");
        if (character.IsPregnant) statusTags.Add($"已怀孕");
        
        // Experiences
        var e = character.Experience;
        if (t.IsVirgin) statusTags.Add("处女");
        else statusTags.Add($"已有本番经验 ({e.Vaginal}次)");
        if (t.IsAnalVirgin) statusTags.Add("后庭处女");
        
        if (statusTags.Any())
        {
            sb.AppendLine($"- 当前状态：{string.Join(", ", statusTags)}");
        }

        // Stats
        int obs = character.BaseStatus.Obedience;
        int res = character.BaseStatus.Resistance;
        sb.AppendLine($"- 服从度：{obs} (数值越高越顺从)");
        sb.AppendLine($"- 反抗刻印：{res} (数值越高反抗情绪越重)");

        if (!string.IsNullOrEmpty(additionalRules))
        {
            sb.AppendLine("【附加演出版规则】");
            sb.AppendLine(additionalRules);
        }
        
        return sb.ToString();
    }
}