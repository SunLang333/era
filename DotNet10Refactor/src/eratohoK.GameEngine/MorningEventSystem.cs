namespace eratohoK.GameEngine;

using eratohoK.Core;

public static class MorningEventSystem
{
    public static MorningEventResult? FireMorningEvent(GameStateManager gameState, Character player, Random rng)
    {
        var allChars = gameState.GetAllCharacters();

        var learner = allChars.FirstOrDefault(c => c.Id != player.Id && c.IsInLove && c.Ability.SexualKnowledge < 3);
        if (learner != null)
        {
            learner.Ability = learner.Ability with { SexualKnowledge = learner.Ability.SexualKnowledge + 1 };
            return new MorningEventResult($"「{learner.Name}は自ら性知識を深めた」");
        }

        if (player.PrisonerOfCountryId > 0)
        {
            player.BaseStatus = player.BaseStatus with { Resistance = Math.Max(0, player.BaseStatus.Resistance - 10) };
            return new MorningEventResult("あなたは囚われの身だ。反抗心が少し薄れた。（反抗-10）");
        }

        if (rng.NextDouble() < 0.3)
        {
            var others = allChars.Where(c => c.Id != player.Id && c.SpecialState == SpecialState.Normal).ToList();
            if (others.Count > 0)
            {
                var greeter = others[rng.Next(others.Count)];
                int like = greeter.GetLikeabilityTowards(player.Id);
                string greeting = like > 50
                    ? $"「おはようございます、{player.Name}様♥」 — {greeter.Name}が嬉しそうに挨拶した。"
                    : like > 0
                    ? $"「...おはよう」 — {greeter.Name}が静かに挨拶した。"
                    : $"「...」 — {greeter.Name}は無言で通り過ぎた。";
                return new MorningEventResult(greeting);
            }
        }

        return null;
    }
}

public record MorningEventResult(string Message);
