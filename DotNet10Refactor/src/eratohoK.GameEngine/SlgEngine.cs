namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// SLG (Strategy Layer Game) エンジン
/// 勢力マップの管理と AI 行動を担当する。
/// <see cref="CommandRoutingService"/> を注入することで調教コマンドにも対応する。
/// </summary>
public class SlgEngine
{
    private const int GoldPerPopulation = 2;
    private const int EconomyPerSoldier = 100;

    private readonly Dictionary<(int, int), int> _countryRelations = new();
    private readonly Random _rng = Random.Shared;
    private readonly CommandRoutingService? _commandRouter;

    /// <summary>
    /// デフォルトコンストラクター（SLG のみ使用する場合）
    /// </summary>
    public SlgEngine() { }

    /// <summary>
    /// 調教コマンドルーティングを含むコンストラクター（DI 用）
    /// </summary>
    /// <param name="commandRouter">調教コマンドのルーティングサービス</param>
    public SlgEngine(CommandRoutingService commandRouter)
    {
        _commandRouter = commandRouter;
    }

    /// <summary>勢力間の関係値を取得する</summary>
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
                int gain = CalculateGoldGain(city);
                city.Gold += gain;
                goldGain += gain;
            }
            if (goldGain > 0)
                log.Add($"  [{country.Name}] 内政を実施。財政 +{goldGain}。");

            // ── Military action: recruit soldiers ──
            int recruit = CalculateSoldierRecruitment(country);
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

    /// <summary>
    /// プレイヤーターンのコマンドを実行する。
    /// <see cref="CommandType.Train"/> の場合は注入された <see cref="CommandRoutingService"/> へ委譲する。
    /// キャラクターオブジェクトは <paramref name="characters"/> から解決される。
    /// </summary>
    /// <param name="command">実行するコマンド</param>
    /// <param name="playerCountry">プレイヤー勢力</param>
    /// <param name="playerCities">プレイヤーの都市一覧</param>
    /// <param name="characters">キャラクター一覧（調教コマンド時に必要）</param>
    public CommandResult ExecutePlayerTurn(
        Command                  command,
        Country                  playerCountry,
        IEnumerable<City>        playerCities,
        IEnumerable<Character>?  characters = null)
    {
        return command.Type switch
        {
            CommandType.Work  => DoInternalWork(playerCountry, playerCities.ToList()),
            CommandType.Train => DoTrain(command, characters),
            CommandType.Battle => new CommandResult(false, "戦闘は未実装です。"),
            _ => new CommandResult(false, $"コマンド '{command.Type}' は未対応です。")
        };
    }

    // ──────────────────────────────────────────────────────────────────────────
    // Private helpers
    // ──────────────────────────────────────────────────────────────────────────

    private CommandResult DoTrain(Command command, IEnumerable<Character>? characters)
    {
        if (_commandRouter == null)
            return new CommandResult(false, "調教ルーターが初期化されていません。CommandRoutingService を注入してください。");

        if (characters == null)
            return new CommandResult(false, "調教コマンドにはキャラクターリストが必要です。");

        var charList = characters.ToList();

        // トレーナーと対象をコマンドから解決
        var trainer = charList.FirstOrDefault(c => c.Id == command.ExecutorCharacterId);
        if (trainer == null)
            return new CommandResult(false, $"トレーナー (ID={command.ExecutorCharacterId}) が見つかりません。");

        if (command.TargetCharacterId == null)
            return new CommandResult(false, "調教コマンドには対象キャラクター ID が必要です。");

        var target = charList.FirstOrDefault(c => c.Id == command.TargetCharacterId);
        if (target == null)
            return new CommandResult(false, $"対象キャラクター (ID={command.TargetCharacterId}) が見つかりません。");

        // アクション定義を Parameters から解決
        if (command.Parameters == null
            || !command.Parameters.TryGetValue("actionDef", out var actionDefObj)
            || actionDefObj is not TrainingActionDef actionDef)
        {
            return new CommandResult(false, "調教コマンドに 'actionDef' パラメータが必要です。");
        }

        var session = new TrainingSession
        {
            TrainerId = trainer.Id,
            TargetId  = target.Id,
            IsForced  = command.Parameters.TryGetValue("isForced", out var forced) && forced is true
        };

        var result = _commandRouter.RouteTrainCommand(trainer, target, actionDef, session);

        return new CommandResult(
            result.Success,
            result.Message,
            result.StatChanges != null
                ? [new SemanticTextOutput("TrainingResult", result.Message)]
                : null);
    }

    private CommandResult DoInternalWork(Country country, List<City> cities)
    {
        int total = 0;
        foreach (var city in cities)
        {
            int gain = CalculateGoldGain(city);
            city.Gold += gain;
            total += gain;
        }
        int soldiers = CalculateSoldierRecruitment(country);
        country.SoldierCount += soldiers;
        return new CommandResult(true,
            $"内政を実施しました。財政 +{total}、兵士 +{soldiers}。");
    }

    private static int CalculateGoldGain(City city) => city.Population * GoldPerPopulation;

    private static int CalculateSoldierRecruitment(Country country) =>
        Math.Max(1, country.EconomyScale / EconomyPerSoldier);
}
