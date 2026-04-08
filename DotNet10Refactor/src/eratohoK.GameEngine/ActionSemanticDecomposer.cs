namespace eratohoK.GameEngine;

using System;
using System.Collections.Generic;
using eratohoK.Core;

/// <summary>
/// 将一次训练动作分解为结构化语义事件，供提示词层和 LLM 润色层消费。
/// </summary>
public static class ActionSemanticDecomposer
{
    public static DialogueSemanticEvent Decompose(
        Character trainer,
        Character target,
        TrainingActionDef action,
        BaseStatus beforeStatus,
        Talent beforeTalent,
        Experience beforeExperience,
        IDictionary<string, int>? statChanges = null)
    {
        var (verb, defaultObject, contextSuffix, additionalRules) = DescribeAction(action.ActionType);
        var objectLabel = ResolveObjectLabel(action.Name, defaultObject);
        var modifiers = BuildModifiers(target, action, beforeStatus, beforeTalent, beforeExperience, statChanges);

        var statDelta = new DialogueStatDelta(
            Joy: target.BaseStatus.Joy - beforeStatus.Joy,
            Obedience: target.BaseStatus.Obedience - beforeStatus.Obedience,
            Resistance: target.BaseStatus.Resistance - beforeStatus.Resistance,
            Corruption: target.BaseStatus.Corruption - beforeStatus.Corruption,
            Physical: target.BaseStatus.Physical - beforeStatus.Physical);

        var sceneContext = $"{trainer.Name}对{target.Name}执行了“{action.Name}”。{contextSuffix}";

        return new DialogueSemanticEvent(
            Subject: DialogueCharacterSnapshot.From(trainer),
            Target: DialogueCharacterSnapshot.From(target),
            ActionType: action.ActionType,
            ActionName: action.Name,
            Verb: verb,
            ObjectLabel: objectLabel,
            Modifiers: modifiers,
            StatDelta: statDelta,
            SceneContext: sceneContext,
            AdditionalRules: additionalRules);
    }

    private static (string Verb, string ObjectLabel, string ContextSuffix, string AdditionalRules) DescribeAction(
        TrainingActionType actionType)
    {
        return actionType switch
        {
            TrainingActionType.Caress => (
                "爱抚与试探",
                "身体与敏感部位",
                "这是一次循序渐进的身体接触。",
                "语气应体现试探、触碰与身体逐步升温的反应，不要跳出当前动作。"),
            TrainingActionType.Oral => (
                "口唇刺激",
                "口唇、舌尖与下身接触",
                "这是一次亲密度较高的身体刺激。",
                "突出呼吸、羞耻、迎合或被迫之间的摇摆，但保持短句。"),
            TrainingActionType.Vaginal => (
                "进入与贯穿",
                "前穴",
                "这是一次直接突破身体防线的核心行为。",
                "重点表现被侵入后的动摇、羞耻、抗拒或沉溺，不要写成长篇说明。"),
            TrainingActionType.Anal => (
                "后穴侵入",
                "后穴",
                "这是一次更具冲击性的侵入行为。",
                "可强调惊愕、紧张、抗拒与异样快感的拉扯。"),
            TrainingActionType.Toy => (
                "器具刺激",
                "器具与身体敏感部位",
                "这是一次借助外物强化刺激的行为。",
                "体现陌生感、机械感或失控感，但不要离开角色视角。"),
            TrainingActionType.Mental => (
                "言语施压与精神支配",
                "意志、羞耻心与心理防线",
                "这是一次偏心理层面的调教。",
                "多表现心理动摇、逞强、屈服或被支配感。"),
            TrainingActionType.Daily => (
                "日常接触与关系试探",
                "关系距离与轻度身体接触",
                "这是日常场景中的轻互动。",
                "像短句闲聊或轻微反应，不要写成激烈场面。"),
            TrainingActionType.Punishment => (
                "惩罚与压制",
                "身体痛感与心理威压",
                "这是一次带惩戒意味的强制行为。",
                "突出疼痛、威压、屈辱或不甘。"),
            TrainingActionType.Reward => (
                "安抚与奖赏",
                "情绪、身体放松与关系回馈",
                "这是一次正向反馈与奖励。",
                "语气偏柔和、安抚、满足或受宠若惊。"),
            _ => (
                "接触与刺激",
                "身体与情绪",
                "发生了一次互动。",
                "保持贴近当前动作，不要自行扩展剧情。")
        };
    }

    private static string ResolveObjectLabel(string actionName, string defaultObject)
    {
        if (actionName.Contains("キス", StringComparison.Ordinal))
            return "嘴唇";
        if (actionName.Contains("胸", StringComparison.Ordinal))
            return "胸部";
        if (actionName.Contains("アナル", StringComparison.Ordinal))
            return "后穴";
        if (actionName.Contains("クンニ", StringComparison.Ordinal))
            return "下身";
        if (actionName.Contains("指", StringComparison.Ordinal))
            return "体内深处";
        if (actionName.Contains("媚薬", StringComparison.Ordinal))
            return "身体感度与情绪";

        return defaultObject;
    }

    private static List<string> BuildModifiers(
        Character target,
        TrainingActionDef action,
        BaseStatus beforeStatus,
        Talent beforeTalent,
        Experience beforeExperience,
        IDictionary<string, int>? statChanges)
    {
        var modifiers = new List<string>();

        switch (action.ActionType)
        {
            case TrainingActionType.Vaginal when beforeTalent.IsVirgin:
                modifiers.Add("这是对其处女防线的首次突破");
                break;
            case TrainingActionType.Anal when beforeTalent.IsAnalVirgin:
                modifiers.Add("这是对其后庭防线的首次突破");
                break;
            case TrainingActionType.Oral when beforeTalent.IsKissInexperienced:
                modifiers.Add("这次互动跨过了初吻或口唇亲密的界线");
                break;
            case TrainingActionType.Mental:
                modifiers.Add("更偏向心理支配而非纯肉体刺激");
                break;
            case TrainingActionType.Punishment:
                modifiers.Add("带有惩戒与压制意味");
                break;
            case TrainingActionType.Reward:
                modifiers.Add("带有安抚与奖赏意味");
                break;
        }

        if (beforeTalent.IsVirgin && !target.Talent.IsVirgin)
            modifiers.Add("刚刚失去了处女身份");
        if (beforeTalent.IsAnalVirgin && !target.Talent.IsAnalVirgin)
            modifiers.Add("刚刚失去了后庭处女身份");
        if (beforeTalent.IsKissInexperienced && !target.Talent.IsKissInexperienced)
            modifiers.Add("刚刚经历了第一次亲吻或口唇亲密");

        if (beforeExperience.Vaginal == 0 && target.Experience.Vaginal > 0)
            modifiers.Add("属于第一次前穴实战经验");
        if (beforeExperience.Anal == 0 && target.Experience.Anal > 0)
            modifiers.Add("属于第一次后穴实战经验");
        if (beforeExperience.Oral == 0 && target.Experience.Oral > 0)
            modifiers.Add("属于第一次明显的口技经验");

        AddStageModifiers(modifiers, target);
        AddDeltaModifiers(modifiers, target.BaseStatus, beforeStatus);

        if (statChanges != null && statChanges.ContainsKey("Pregnant"))
            modifiers.Add("这次行为带来了受孕或怀孕的可能");
        if (target.IsPregnant)
            modifiers.Add("目标当前已经处于怀孕状态");

        return modifiers;
    }

    private static void AddStageModifiers(List<string> modifiers, Character target)
    {
        modifiers.Add(target.BaseStatus.Resistance switch
        {
            > 400 => "当前反抗情绪很高",
            > 150 => "当前仍有明显抗拒",
            _ => "当前反抗已经明显减弱"
        });

        modifiers.Add(target.BaseStatus.Obedience switch
        {
            > 500 => "当前顺从度很高",
            > 200 => "当前顺从度正在形成",
            _ => "当前顺从度仍然有限"
        });

        modifiers.Add(target.BaseStatus.Joy switch
        {
            > 400 => "身体快感已经非常强烈",
            > 150 => "身体快感正在上升",
            _ => "身体快感仍处于较低或压抑阶段"
        });
    }

    private static void AddDeltaModifiers(List<string> modifiers, BaseStatus after, BaseStatus before)
    {
        int joyDelta = after.Joy - before.Joy;
        int obedienceDelta = after.Obedience - before.Obedience;
        int resistanceDelta = after.Resistance - before.Resistance;
        int corruptionDelta = after.Corruption - before.Corruption;
        int physicalDelta = after.Physical - before.Physical;

        if (joyDelta >= 15)
            modifiers.Add("快感显著上升");
        else if (joyDelta > 0)
            modifiers.Add("快感有所上升");

        if (obedienceDelta >= 8)
            modifiers.Add("顺从度显著上升");
        else if (obedienceDelta > 0)
            modifiers.Add("顺从度略有上升");

        if (resistanceDelta <= -6)
            modifiers.Add("反抗心被明显削弱");
        else if (resistanceDelta < 0)
            modifiers.Add("反抗心略有下降");

        if (corruptionDelta >= 6)
            modifiers.Add("堕落倾向明显加深");
        else if (corruptionDelta > 0)
            modifiers.Add("堕落倾向略有加深");

        if (physicalDelta < 0)
            modifiers.Add("这次行为消耗了不少体力");
    }
}
