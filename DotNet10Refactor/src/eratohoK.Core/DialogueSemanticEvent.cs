namespace eratohoK.Core;

using System.Collections.Generic;

/// <summary>
/// 供口上生成使用的角色状态快照。
/// 避免在训练结果中直接持有可变 <see cref="Character"/> 实例，导致后续状态漂移污染已生成的语义事件。
/// </summary>
public record DialogueCharacterSnapshot(
    int Id,
    int No,
    string Name,
    Gender Gender,
    BaseStatus BaseStatus,
    Talent Talent,
    Experience Experience,
    bool IsInLove,
    bool IsLover,
    bool IsPregnant)
{
    public static DialogueCharacterSnapshot From(Character character) => new(
        character.Id,
        character.No,
        character.Name,
        character.Gender,
        character.BaseStatus,
        character.Talent,
        character.Experience,
        character.IsInLove,
        character.IsLover,
        character.IsPregnant);

    /// <summary>
    /// 为旧的反应系统回退路径恢复一个最小可用的 <see cref="Character"/> 视图。
    /// </summary>
    public Character ToCharacter() => new()
    {
        Id = Id,
        No = No,
        Name = Name,
        Gender = Gender,
        BaseStatus = BaseStatus,
        Talent = Talent,
        Experience = Experience,
        IsInLove = IsInLove,
        IsLover = IsLover,
        IsPregnant = IsPregnant
    };
}

/// <summary>
/// 描述本次互动对目标造成的核心数值变化。
/// </summary>
public record DialogueStatDelta(
    int Joy = 0,
    int Obedience = 0,
    int Resistance = 0,
    int Corruption = 0,
    int Physical = 0
);

/// <summary>
/// 结构化的口上语义事件。
/// 使用“施动者 / 行为 / 作用对象”作为骨架，再附加修饰语、场景和数值变化给提示词层消费。
/// </summary>
public record DialogueSemanticEvent(
    DialogueCharacterSnapshot Subject,
    DialogueCharacterSnapshot Target,
    TrainingActionType ActionType,
    string ActionName,
    string Verb,
    string ObjectLabel,
    IReadOnlyList<string>? Modifiers = null,
    DialogueStatDelta? StatDelta = null,
    string SceneContext = "",
    string AdditionalRules = ""
);
