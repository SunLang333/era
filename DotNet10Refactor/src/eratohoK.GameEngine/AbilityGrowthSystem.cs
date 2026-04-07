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

        // Check for 恋慕 (IsInLove) based on Obedience and Joy
        if (!character.IsInLove && character.BaseStatus.Obedience >= 500 && character.BaseStatus.Joy >= 300)
        {
            character.IsInLove = true;
            msgs.Add(ReactionSystem.GetFirstTimeReaction("恋慕"));
            msgs.Add($"{character.Name}はあなたに【恋慕】を抱いたようです。");
        }

        // Check for 恋人 (IsLover)
        if (!character.IsLover && character.IsInLove && character.BaseStatus.Obedience >= 800 && character.BaseStatus.Joy >= 800)
        {
            character.IsLover = true;
            msgs.Add(ReactionSystem.GetFirstTimeReaction("恋人"));
            msgs.Add($"{character.Name}はあなたの【恋人】になりました。");
        }

        return msgs;
    }
}
