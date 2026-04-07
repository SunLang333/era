namespace eratohoK.GameEngine;

using eratohoK.Core;

public static class TurnEndProcessor
{
    public static TurnEndResult ProcessTurnEnd(GameStateManager gameState, GameConfig config, Random rng)
    {
        int goldGained = 0;
        var events = new List<string>();
        var playerCountry = gameState.GetCountry(gameState.PlayerCountryId);

        // 1. Income from player cities
        foreach (var city in gameState.GetAllCities().Where(c => c.CountryId == gameState.PlayerCountryId))
        {
            double ecoBonus = playerCountry != null ? TechSystem.GetEconomyBonus(playerCountry) : 0.0;
            int gain = (int)((city.Population * 2 + city.Gold / 10) * (1.0 + ecoBonus));
            goldGained += gain;
        }

        // 2. Pregnancy progression (weekly check every 7 days)
        int dayOfYear = gameState.CurrentDate.DayOfYear;
        if (dayOfYear % 7 == 0)
        {
            foreach (var ch in gameState.GetAllCharacters())
            {
                var ev = PregnancySystem.ProgressPregnancy(ch, rng);
                if (ev != null) events.Add(ev.Message ?? $"{ch.Name}: 妊娠イベント発生");
                
                var childEv = PregnancySystem.ProgressChildcare(ch);
                if (childEv != null) events.Add(childEv.Message ?? $"{ch.Name}: 育児イベント");
            }
            foreach (var ch in gameState.GetAllCharacters())
                ch.IsDangerDay = rng.NextDouble() < 0.2;
        }

        // 3. ABL growth
        foreach (var ch in gameState.GetAllCharacters())
        {
            var growthMsgs = AbilityGrowthSystem.CheckGrowth(ch, config);
            events.AddRange(growthMsgs);
        }

        // 4. Skill TurnEnd passives
        foreach (var ch in gameState.GetAllCharacters())
        {
            var skillMsgs = SkillEngine.ProcessTurnEndPassives(ch, config);
            events.AddRange(skillMsgs);
        }

        // 5. Special faction events (5% chance per AI country of internal strife)
        foreach (var country in gameState.GetAllCountries().Where(c => c.IsAIControlled && !c.IsDestroyed))
        {
            if (rng.NextDouble() < 0.05)
            {
                int loss = Math.Max(1, country.SoldierCount / 10);
                country.SoldierCount = Math.Max(0, country.SoldierCount - loss);
                events.Add($"[{country.Name}] 内部抗争発生。兵士 -{loss}。");
            }
        }

        // 6. Diplomacy countdown
        if (gameState.DiplomacyTrainedDay > 0)
        {
            gameState.DiplomacyTrainedDay--;
            if (gameState.DiplomacyTrainedDay == 0)
                events.Add("外交調教の期限が来た。");
        }

        return new TurnEndResult(goldGained, events);
    }
}

public record TurnEndResult(int GoldGained, List<string> Events);
