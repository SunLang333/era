namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// SLG (Strategy Layer Game) エンジン
/// 勢力マップの管理と AI 行動を担当する
/// </summary>
public class SlgEngine
{
    private readonly Dictionary<(int, int), int> _countryRelations = new();
    private readonly Random _rng = Random.Shared;

    public int GetRelation(int countryIdA, int countryIdB)
    {
        var key = countryIdA < countryIdB ? (countryIdA, countryIdB) : (countryIdB, countryIdA);
        return _countryRelations.GetValueOrDefault(key, 0);
    }

    private void AdjustRelation(int countryIdA, int countryIdB, int delta)
    {
        var key = countryIdA < countryIdB ? (countryIdA, countryIdB) : (countryIdB, countryIdA);
        var current = _countryRelations.GetValueOrDefault(key, 0);
        _countryRelations[key] = Math.Clamp(current + delta, -100, 100);
    }

    /// <summary>すべての AI 勢力の行動を実行し、ログを返す</summary>
    public List<string> ExecuteAllAiActions(IEnumerable<Country> countries, IEnumerable<City> cities)
    {
        var log = new List<string>();
        var cityList = cities.ToList();
        var aiCountries = countries.Where(c => c.IsAIControlled && !c.IsDestroyed).ToList();

        foreach (var country in aiCountries)
        {
            // ── Internal action: grow economy ──
            int goldGain = 0;
            foreach (var city in cityList.Where(c => c.CountryId == country.Id))
            {
                int gain = city.Population * 2;
                city.Gold += gain;
                goldGain += gain;
            }
            if (goldGain > 0)
                log.Add($"  [{country.Name}] 内政を実施。財政 +{goldGain}。");

            // ── Military action: recruit soldiers ──
            int recruit = Math.Max(1, country.EconomyScale / 100);
            country.SoldierCount += recruit;
            log.Add($"  [{country.Name}] 兵士を徴兵。兵数 +{recruit} (合計: {country.SoldierCount})。");

            // ── Diplomacy: randomly improve relations ──
            var others = aiCountries.Where(c => c.Id != country.Id).ToList();
            if (others.Count > 0)
            {
                var target = others[_rng.Next(others.Count)];
                int delta = _rng.Next(1, 6);
                AdjustRelation(country.Id, target.Id, delta);
                log.Add($"  [{country.Name}] {target.Name}との外交を強化。関係度 +{delta}。");
            }
        }

        return log;
    }

    /// <summary>プレイヤーターンのコマンドを実行する</summary>
    public CommandResult ExecutePlayerTurn(
        Command command, Country playerCountry, IEnumerable<City> playerCities)
    {
        return command.Type switch
        {
            CommandType.Work => DoInternalWork(playerCountry, playerCities.ToList()),
            CommandType.Battle => new CommandResult(false, "戦闘は未実装です。"),
            _ => new CommandResult(false, $"コマンド '{command.Type}' は未対応です。")
        };
    }

    private CommandResult DoInternalWork(Country country, List<City> cities)
    {
        int total = 0;
        foreach (var city in cities)
        {
            int gain = city.Population * 2;
            city.Gold += gain;
            total += gain;
        }
        int soldiers = Math.Max(1, country.EconomyScale / 100);
        country.SoldierCount += soldiers;
        return new CommandResult(true,
            $"内政を実施しました。財政 +{total}、兵士 +{soldiers}。");
    }
}
