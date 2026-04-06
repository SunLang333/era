namespace eratohoK.Cli;

using eratohoK.Core;
using eratohoK.Data;
using eratohoK.GameEngine;

class Program
{
    // After this many base-phase days the SLG (strategy) phase is triggered
    // (matches the original eratohoK SHOP_TIME cycle of 3 actions per turn)
    private const int SlgTriggerDay = 3;
    private const int MaxDisplayedCharacters = 20;
    private const int MaxDisplayedActions = 15;
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var csvDirectory = args.Length > 0 ? args[0] : "../CSV";

        ShowTitle();

        while (true)
        {
            Console.WriteLine("[1] New Game");
            Console.WriteLine("[2] Load Game (未実装)");
            Console.WriteLine("[3] Quit");
            Console.Write("> ");
            var choice = ReadLine();

            switch (choice)
            {
                case "1":
                    RunNewGame(csvDirectory);
                    break;
                case "2":
                    Console.WriteLine("ロード機能は未実装です。");
                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine("ゲームを終了します。");
                    return;
                default:
                    Console.WriteLine("無効な入力です。");
                    Console.WriteLine();
                    break;
            }
        }
    }

    // ────────────────── New Game ──────────────────

    static void RunNewGame(string csvDirectory)
    {
        Console.WriteLine();
        Console.WriteLine("データを読み込んでいます...");

        List<Character> characters = new();
        List<TrainDefinition> trainDefs = new();

        if (Directory.Exists(csvDirectory))
        {
            using var csv = new CsvDataReader(csvDirectory);
            characters = csv.LoadAllCharacters();
            trainDefs = csv.ReadTrainDefinitions();
            Console.WriteLine($"  キャラクター {characters.Count} 人、調教アクション {trainDefs.Count} 個を読み込みました。");
        }
        else
        {
            Console.WriteLine($"  警告: CSV ディレクトリが見つかりません ({csvDirectory})。デモデータを使用します。");
            characters = BuildDemoCharacters();
            trainDefs = BuildDemoTrainDefs();
        }

        if (characters.Count == 0)
        {
            Console.WriteLine("キャラクターデータがありません。");
            Console.WriteLine();
            return;
        }

        // Select player character (trainer)
        var player = SelectCharacter(characters, "プレイヤーキャラクターを選択してください:");
        if (player == null) return;

        // The trainable targets are everyone except the player
        var targets = characters.Where(c => c.Id != player.Id).ToList();
        if (targets.Count == 0)
        {
            Console.WriteLine("調教できるキャラクターがいません。");
            Console.WriteLine();
            return;
        }

        // Build training action defs from definitions
        var actionDefs = trainDefs.Select(t => new TrainingActionDef(t.Id, t.Name)).ToList();
        var trainingEngine = new TrainingEngine(actionDefs);

        // Setup game state and SLG
        var gameState = BuildDemoGameState(characters);
        var slgEngine = new SlgEngine();
        var gameEngine = new GameEngine(gameState);
        gameEngine.StartGame();

        Console.WriteLine();
        Console.WriteLine($"「{player.Name}」でゲームを開始します！");
        Console.WriteLine();

        int day = 1;

        while (true)
        {
            Console.WriteLine($"═══════════════════════════════");
            Console.WriteLine($"  Day {day}  [{gameState.CurrentDate:yyyy/MM/dd}]");
            Console.WriteLine($"═══════════════════════════════");
            Console.WriteLine("[1] 調教");
            Console.WriteLine("[2] 休息 (次の日へ)");
            Console.WriteLine("[3] ステータス確認");
            Console.WriteLine("[4] タイトルへ戻る");
            Console.Write("> ");
            var cmd = ReadLine();

            switch (cmd)
            {
                case "1":
                    DoTraining(player, targets, trainingEngine);
                    break;
                case "2":
                    gameState.AdvanceTurn();
                    day++;
                    Console.WriteLine($"  休息しました。Day {day} になりました。");
                    Console.WriteLine();
                    if (day > SlgTriggerDay)
                    {
                        ShowSlgPhase(gameState, slgEngine);
                        day = 1;
                        gameState.CurrentDate = gameState.CurrentDate.AddDays(1);
                    }
                    break;
                case "3":
                    ShowStatus(player, targets);
                    break;
                case "4":
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine("無効な入力です。");
                    Console.WriteLine();
                    break;
            }
        }
    }

    // ────────────────── Training ──────────────────

    static void DoTraining(Character player, List<Character> targets, TrainingEngine engine)
    {
        Console.WriteLine();
        var target = SelectCharacter(targets, "調教するキャラクターを選択:");
        if (target == null) return;

        if (engine.AvailableActions.Count == 0)
        {
            Console.WriteLine("  利用可能なアクションがありません。");
            Console.WriteLine();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("── アクションを選択 ──");
        for (int i = 0; i < Math.Min(engine.AvailableActions.Count, MaxDisplayedActions); i++)
        {
            var a = engine.AvailableActions[i];
            Console.WriteLine($"  [{i}] {a.Name} ({a.TimeRequired}分)");
        }
        Console.Write("> ");
        var input = ReadLine();

        if (!int.TryParse(input, out var idx) || idx < 0 || idx >= engine.AvailableActions.Count)
        {
            Console.WriteLine("  キャンセルしました。");
            Console.WriteLine();
            return;
        }

        var session = engine.CreateSession(player.Id, target.Id);
        var result = engine.ExecuteAction(session, player, target, engine.AvailableActions[idx].Id);

        Console.WriteLine();
        Console.WriteLine($"【{result.ActionName}】を実行しました。");
        if (result.StatChanges != null)
        {
            Console.WriteLine("  ── ステータス変化 ──");
            foreach (var kv in result.StatChanges)
                Console.WriteLine($"    {kv.Key}: {(kv.Value >= 0 ? "+" : "")}{kv.Value}");
        }
        Console.WriteLine($"  使用時間: {session.TimeUsed}分");
        Console.WriteLine();
        Console.Write("  [Enter で続ける]");
        ReadLine();
        Console.WriteLine();
    }

    // ────────────────── SLG Phase ──────────────────

    static void ShowSlgPhase(GameStateManager gameState, SlgEngine slgEngine)
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║      SLG フェーズ             ║");
        Console.WriteLine("╚══════════════════════════════╝");
        Console.WriteLine("各勢力が行動します...");
        Console.WriteLine();

        var logs = slgEngine.ExecuteAllAiActions(
            gameState.GetAllCountries(),
            gameState.GetAllCities());

        if (logs.Count == 0)
            Console.WriteLine("  AI 勢力の行動はありませんでした。");
        else
            foreach (var entry in logs)
                Console.WriteLine(entry);

        Console.WriteLine();
        Console.Write("[Enter で続ける]");
        ReadLine();
        Console.WriteLine();
    }

    // ────────────────── Status ──────────────────

    static void ShowStatus(Character player, List<Character> targets)
    {
        Console.WriteLine();
        Console.WriteLine("── ステータス確認 ──");
        var target = SelectCharacter(targets, "確認するキャラクターを選択:");
        if (target == null) return;

        Console.WriteLine();
        Console.WriteLine($"  名前     : {target.Name} ({target.Nickname})");
        Console.WriteLine($"  性別     : {target.Gender}");
        Console.WriteLine($"  体力     : {target.BaseStatus.Physical}");
        Console.WriteLine($"  気力     : {target.BaseStatus.Mental}");
        Console.WriteLine($"  服従度   : {target.BaseStatus.Obedience}");
        Console.WriteLine($"  堕落度   : {target.BaseStatus.Corruption}");
        Console.WriteLine($"  反抗心   : {target.BaseStatus.Resistance}");
        Console.WriteLine($"  愉悦     : {target.BaseStatus.Joy}");
        Console.WriteLine($"  武闘     : {target.Ability.Fight}");
        Console.WriteLine($"  知略     : {target.Ability.Intelligence}");
        Console.WriteLine($"  政治     : {target.Ability.Politics}");
        Console.WriteLine();
    }

    // ────────────────── Helpers ──────────────────

    static void ShowTitle()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║   eratohoK Reborn  (.NET 10 Refactored)  ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.WriteLine();
    }

    static Character? SelectCharacter(List<Character> characters, string prompt)
    {
        Console.WriteLine();
        Console.WriteLine(prompt);
        int shown = Math.Min(characters.Count, MaxDisplayedCharacters);
        for (int i = 0; i < shown; i++)
        {
            var c = characters[i];
            var tags = string.Join("/", new[]
            {
                c.Talent.IsVirgin ? "処女" : null,
                c.Talent.IsOptimistic ? "楽観的" : null
            }.Where(t => t != null));
            var tagStr = tags.Length > 0 ? $" [{tags}]" : "";
            Console.WriteLine($"  [{i}] {c.Name}{tagStr}");
        }
        if (characters.Count > shown)
            Console.WriteLine($"  ...他 {characters.Count - shown} 人");
        Console.Write("> ");
        var input = ReadLine();
        if (!int.TryParse(input, out var idx) || idx < 0 || idx >= shown)
        {
            Console.WriteLine("  キャンセルしました。");
            Console.WriteLine();
            return null;
        }
        return characters[idx];
    }

    static string ReadLine() => Console.ReadLine() ?? "";

    // ────────────────── Demo data ──────────────────

    static List<Character> BuildDemoCharacters() =>
    [
        new Character { Id = 0, No = 0, Name = "あなた", Nickname = "主人公", Gender = Gender.Male,
            BaseStatus = new BaseStatus(Physical: 500, Mental: 500),
            Ability = new Ability(Fight: 50, Politics: 40, Intelligence: 60) },
        new Character { Id = 1, No = 1, Name = "霊夢", Nickname = "博麗の巫女", Gender = Gender.Female,
            BaseStatus = new BaseStatus(Physical: 2400, Mental: 1400, Resistance: 300),
            Ability = new Ability(Fight: 81, Command: 65, Intelligence: 50, Politics: 61),
            Talent = new Talent(Gender: Gender.Female, IsVirgin: true, IsOptimistic: true) },
        new Character { Id = 2, No = 2, Name = "魔理沙", Nickname = "普通の魔法使い", Gender = Gender.Female,
            BaseStatus = new BaseStatus(Physical: 2000, Mental: 1800, Resistance: 250),
            Ability = new Ability(Fight: 75, Magic: 90, Intelligence: 70, Politics: 40),
            Talent = new Talent(Gender: Gender.Female, IsVirgin: true, IsCurious: true) }
    ];

    static List<TrainDefinition> BuildDemoTrainDefs() =>
    [
        new(0, "愛撫"), new(1, "胸愛撫"), new(2, "クンニ"), new(3, "指挿入れ"), new(4, "アナル愛撫")
    ];

    static GameStateManager BuildDemoGameState(List<Character> characters)
    {
        var gs = new GameStateManager();
        foreach (var c in characters) gs.AddCharacter(c);

        var c1 = new Country { Id = 1, Name = "博麗神社", BossCharacterId = 1,
            EconomyScale = 300, SoldierCount = 50, IsAIControlled = true };
        var c2 = new Country { Id = 2, Name = "霧の湖", BossCharacterId = 2,
            EconomyScale = 200, SoldierCount = 30, IsAIControlled = true };
        var c3 = new Country { Id = 3, Name = "紅魔館", BossCharacterId = 3,
            EconomyScale = 500, SoldierCount = 100, IsAIControlled = true };
        gs.AddCountry(c1); gs.AddCountry(c2); gs.AddCountry(c3);

        gs.AddCity(new City { Id = 1, Name = "博麗神社", CountryId = 1, Population = 50, Gold = 1000, Defense = 100 });
        gs.AddCity(new City { Id = 2, Name = "霧の湖", CountryId = 2, Population = 30, Gold = 800, Defense = 80 });
        gs.AddCity(new City { Id = 3, Name = "紅魔館", CountryId = 3, Population = 100, Gold = 5000, Defense = 300 });

        gs.PlayerCountryId = 1;
        return gs;
    }
}

