namespace eratohoK.GameEngine;

using eratohoK.Core;

public static class SkillEngine
{
    public static List<string> ProcessTurnEndPassives(Character character, GameConfig config)
    {
        var msgs = new List<string>();
        foreach (var skill in character.Skills)
        {
            switch (skill.Id)
            {
                case 0:
                    character.Experience = character.Experience with {
                        Vaginal = character.Experience.Vaginal + 5 * skill.Level,
                        Oral    = character.Experience.Oral    + 5 * skill.Level,
                        Anal    = character.Experience.Anal    + 5 * skill.Level
                    };
                    msgs.Add($"{character.Name}【超成長力】経験値 +{5*skill.Level}");
                    break;
                case 20:
                    if (character.BaseStatus.Resistance > 0)
                    {
                        character.BaseStatus = character.BaseStatus with {
                            Resistance = Math.Max(0, character.BaseStatus.Resistance - 5 * skill.Level) };
                        msgs.Add($"{character.Name}【破壊衝動】反抗 -{5*skill.Level}");
                    }
                    break;
            }
        }
        return msgs;
    }

    public static List<string> ProcessCommandPassives(Character trainer, Character target,
        TrainingActionType actionType, GameConfig config)
    {
        var msgs = new List<string>();
        foreach (var skill in trainer.Skills)
        {
            switch (skill.Id)
            {
                case 10 when actionType is TrainingActionType.Caress or TrainingActionType.Daily:
                    int bonus = 30 * skill.Level;
                    target.UpdateLikeability(trainer.Id, bonus);
                    msgs.Add($"【魅了】{target.Name}: 好感度 +{bonus}");
                    break;
            }
        }
        return msgs;
    }

    public static SkillResult? TryActivateSkill(Character user, int skillId, Character? target, GameConfig config)
    {
        var skill = user.Skills.FirstOrDefault(s => s.Id == skillId);
        if (skill == null) return new SkillResult(false, "スキルを所持していません。", null);

        if (skillId == 2)
        {
            if (target == null) return new SkillResult(false, "対象が必要です。", null);
            int restore = 500 * skill.Level;
            target.BaseStatus = target.BaseStatus with { Physical = Math.Min(1000, target.BaseStatus.Physical + restore) };
            user.BaseStatus = user.BaseStatus with { Mental = Math.Max(0, user.BaseStatus.Mental - 100) };
            return new SkillResult(true, $"【治療】{target.Name}の体力を{restore}回復した。",
                new Dictionary<string, int> { ["Physical"] = restore, ["Mental"] = -100 });
        }

        if (skillId == 3)
        {
            if (target == null) return new SkillResult(false, "対象が必要です。", null);
            int joyBonus = 50 * skill.Level;
            target.BaseStatus = target.BaseStatus with { Joy = Math.Min(1000, target.BaseStatus.Joy + joyBonus) };
            return new SkillResult(true, $"【鼓舞】{target.Name}の愉悦を{joyBonus}上げた。",
                new Dictionary<string, int> { ["Joy"] = joyBonus });
        }

        return new SkillResult(false, $"スキルID {skillId} はアクティブ発動非対応です。", null);
    }
}

public record SkillResult(bool Success, string Message, Dictionary<string, int>? StatChanges);
