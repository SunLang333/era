namespace eratohoK.GameEngine;

using eratohoK.Core;

public static class PregnancySystem
{
    public static string? CheckConception(Character target, bool hasDangerDay, bool useCondom, GameConfig config, Random rng)
    {
        if (!config.AllowPregnancy) return null;
        if (target.Gender == Gender.Male) return null;
        if (target.IsPregnant) return null;

        double rate = 0.15;
        if (hasDangerDay) rate *= 2.0;
        if (useCondom) rate *= 0.1;

        if (rng.NextDouble() < rate)
        {
            target.IsPregnant = true;
            target.IsDangerDay = false;
            target.PregnancyWeek = 0;
            return $"{target.Name}が妊娠した…";
        }
        return null;
    }

    public static PregnancyEvent? ProgressPregnancy(Character character, Random rng)
    {
        if (!character.IsPregnant) return null;

        character.PregnancyWeek++;

        if (character.PregnancyWeek == 5)
            return new PregnancyEvent($"{character.Name}がつわりで苦しんでいる。");

        if (character.PregnancyWeek >= 40)
        {
            character.IsPregnant = false;
            character.PregnancyWeek = 0;
            character.ChildcareWeek = 20; // 20 weeks of childcare
            character.ActionDisabledState = ActionDisabledState.Childcare;
            return new PregnancyEvent($"{character.Name}が出産した！しばらく育児に専念する。");
        }

        return null;
    }

    public static PregnancyEvent? ProgressChildcare(Character character)
    {
        if (character.ActionDisabledState != ActionDisabledState.Childcare) return null;

        if (character.ChildcareWeek > 0)
        {
            character.ChildcareWeek--;
            if (character.ChildcareWeek == 0)
            {
                character.ActionDisabledState = ActionDisabledState.Normal;
                return new PregnancyEvent($"{character.Name}の育児期間が終わり、復帰した。");
            }
        }
        return null;
    }
}

public record PregnancyEvent(string? Message);
