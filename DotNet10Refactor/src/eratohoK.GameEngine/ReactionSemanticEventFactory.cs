namespace eratohoK.GameEngine;

using System.Collections.Generic;
using eratohoK.Core;

/// <summary>
/// 为非训练动作类的口上（如首次事件、回合结束反应）构建统一的结构化语义事件。
/// </summary>
public static class ReactionSemanticEventFactory
{
    public static DialogueSemanticEvent CreateSessionEndEvent(Character target)
    {
        var modifiers = BuildSharedStateModifiers(target);
        modifiers.Add(target.BaseStatus.Joy switch
        {
            > 400 => "身体还残留着强烈余韵",
            > 150 => "身体仍有明显余热与轻微战栗",
            _ => "身体正在从互动后缓慢平复"
        });
        modifiers.Add(target.BaseStatus.Obedience switch
        {
            > 500 => "更像是在回味主人的支配与安排",
            > 200 => "对刚才的互动有复杂但逐渐软化的态度",
            _ => "仍在强撑情绪或试图整理心情"
        });

        if (target.IsLover)
            modifiers.Add("关系已经足够亲密，反应里可以带依恋与留恋");
        else if (target.IsInLove)
            modifiers.Add("已经带有恋慕情绪，余韵里可混入眷恋");

        return CreateSelfFocusedEvent(
            target,
            TrainingActionType.Daily,
            "本次调教结束",
            "回味与收束",
            "整场互动留下的身体余韵与心理余波",
            modifiers,
            "角色正在回顾刚才发生的一连串行为，并在结束时给出一句短短的余韵反应。",
            "像事后喘息、低语、逞强或依恋的收束反应，不要重新完整复述刚才的具体动作。");
    }

    public static DialogueSemanticEvent CreateMilestoneEvent(Character target, string milestone)
    {
        var modifiers = BuildSharedStateModifiers(target);
        var (actionType, verb, objectLabel, sceneContext, additionalRules, milestoneModifiers) = milestone switch
        {
            "初キス" => (
                TrainingActionType.Daily,
                "跨过第一次亲吻界线",
                "嘴唇与亲密接触",
                "角色刚刚迎来了第一次真正意义上的亲吻或口唇亲密接触。",
                "重点表现青涩、惊讶、羞耻和呼吸被打乱的瞬间感，不要写成长篇告白。",
                new[] { "这是值得记住的第一次唇与唇的突破", "应强调惊讶、脸热、心跳与短暂失神" }),
            "処女喪失" => (
                TrainingActionType.Vaginal,
                "突破第一次前穴防线",
                "处女防线与身体深处",
                "角色刚刚失去了处女之身，这是一次极其重大的身心界线突破。",
                "重点表现失去重要防线后的震动、茫然、羞耻、哭腔或强撑，不要写说明文。",
                new[] { "这是极其强烈的第一次身体突破", "应突出防线破碎后的失重感与情绪晃动" }),
            "アナル初体験" => (
                TrainingActionType.Anal,
                "迎来第一次后穴体验",
                "后穴与陌生的侵入感",
                "角色刚刚经历了前所未有的后穴初体验。",
                "重点表现惊愕、紧绷、抗拒与异样刺激交错的复杂反应。",
                new[] { "这是后庭防线的首次被突破", "应突出陌生感、紧张与受冲击后的发颤" }),
            "恋慕" => (
                TrainingActionType.Reward,
                "意识到恋慕之情",
                "对主人的依恋与心意",
                "角色刚刚确认自己对对方产生了明确的恋慕情绪。",
                "重点表现心动、迟疑、自我察觉与羞涩，不要直接写成长篇告白独白。",
                new[] { "这是情感层面的重要突破", "语气可以更柔软、飘忽、带点不敢承认" }),
            "恋人" => (
                TrainingActionType.Reward,
                "确认恋人关系",
                "关系名分与亲密承诺",
                "角色刚刚跨入恋人阶段，这意味着关系有了明确归属。",
                "重点表现安心、依恋、羞涩和想留在对方身边的情绪。",
                new[] { "这是关系升格后的稳定依恋", "可以带明显的撒娇、眷恋或低声请求" }),
            _ => (
                TrainingActionType.Daily,
                "迎来重要转折",
                "身体或心理的重要界线",
                "角色刚刚迎来了一个非常重要的第一次里程碑。",
                "把重点放在第一次突破后的短促反应，不要写成长篇叙述。",
                new[] { "这是一次具有纪念意义的首次突破" })
        };

        modifiers.AddRange(milestoneModifiers);

        return CreateSelfFocusedEvent(
            target,
            actionType,
            $"达成重要里程碑：{milestone}",
            verb,
            objectLabel,
            modifiers,
            sceneContext,
            additionalRules);
    }

    private static DialogueSemanticEvent CreateSelfFocusedEvent(
        Character target,
        TrainingActionType actionType,
        string actionName,
        string verb,
        string objectLabel,
        IReadOnlyList<string> modifiers,
        string sceneContext,
        string additionalRules)
    {
        var snapshot = DialogueCharacterSnapshot.From(target);
        return new DialogueSemanticEvent(
            Subject: snapshot,
            Target: snapshot,
            ActionType: actionType,
            ActionName: actionName,
            Verb: verb,
            ObjectLabel: objectLabel,
            Modifiers: modifiers,
            StatDelta: null,
            SceneContext: sceneContext,
            AdditionalRules: additionalRules);
    }

    private static List<string> BuildSharedStateModifiers(Character target)
    {
        var modifiers = new List<string>();

        modifiers.Add(target.BaseStatus.Resistance switch
        {
            > 400 => "当前内心仍有很强的抗拒与戒备",
            > 150 => "当前内心仍残留明显抗拒",
            _ => "当前内心抗拒感已经明显缓和"
        });

        modifiers.Add(target.BaseStatus.Obedience switch
        {
            > 500 => "当前顺从与依赖都已经很深",
            > 200 => "当前顺从正在形成但还不彻底",
            _ => "当前还没有完全放下防备"
        });

        if (target.Talent.IsTsundere)
            modifiers.Add("角色带有傲娇气质，可能嘴硬但情绪外露");
        if (target.Talent.IsShy)
            modifiers.Add("角色容易害羞，反应里可带回避、脸热与支吾");
        if (target.Talent.IsStoic)
            modifiers.Add("角色倾向强撑与克制，不会轻易把情绪全部喊出来");
        if (target.IsPregnant)
            modifiers.Add("当前已经怀孕，身体和心理都更容易被触发复杂反应");

        return modifiers;
    }
}
