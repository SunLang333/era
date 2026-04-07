namespace eratohoK.GameEngine;

using eratohoK.Core;

public static class AbilityGrowthSystem
{
    public static List<string> CheckGrowth(Character character, GameConfig config)
    {
        var msgs = new List<string>();
        var exp  = character.Experience;
        var abl  = character.Ability;

        int sexExp = exp.Vaginal + exp.Anal + exp.Oral;
        int newSK = abl.SexualKnowledge;
        if      (newSK < 1 && sexExp >= 200)  newSK = 1;
        else if (newSK < 2 && sexExp >= 500)  newSK = 2;
        else if (newSK < 3 && sexExp >= 1500) newSK = 3;
        if (newSK != abl.SexualKnowledge)
        {
            character.Ability = character.Ability with { SexualKnowledge = newSK };
            msgs.Add($"{character.Name}【性知識】Lv{newSK} にアップ！");
        }

        if (abl.Desire < 1 && character.BaseStatus.Joy >= 100)
        {
            character.Ability = character.Ability with { Desire = 1 };
            msgs.Add($"{character.Name}【欲望】Lv1 にアップ！");
        }

        if (abl.Dominance < 1 && exp.Hand >= 50)
        {
            character.Ability = character.Ability with { Dominance = 1 };
            msgs.Add($"{character.Name}【主導度】Lv1 にアップ！");
        }

        if (abl.Talk < 1 && exp.Hand >= 100)
        {
            character.Ability = character.Ability with { Talk = 1 };
            msgs.Add($"{character.Name}【話術】Lv1 にアップ！");
        }

        return msgs;
    }
}
