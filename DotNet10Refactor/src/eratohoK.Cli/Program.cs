namespace eratohoK.Cli;

using eratohoK.Core;
using eratohoK.Data;
using eratohoK.GameEngine;

class Program
{
    // ── Game constants ─────────────────────────────────────────────
    private const int SlgTriggerDay       = 3;   // days in base phase before SLG triggers
    private const int MaxDisplayedChars   = 20;
    private const int MaxDisplayedActions = 20;
    private const int TurnLimit           = 365; // game ends after this many days
    private const int ObedienceWinThresh  = 700; // obedience needed per target for "good" end
    private const int GoldPerDay          = 200; // gold earned from rest action
    private const int ShopMaxDisplay      = 20;

    // ── Save / data ────────────────────────────────────────────────
    private static readonly SaveSystem Saves = new();
    private static readonly BattleEngine BattleEng = new();

    // ── Runtime state (passed through helpers) ─────────────────────
    private static List<ShopItem> _shopItems = [];

    // ══════════════════════════════════════════════════════════════
    //  Entry Point
    // ══════════════════════════════════════════════════════════════
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var modelPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\qwen3-0.6b-abliterated.q4_k_m.gguf"));
        ReactionSystem.TextGenerator = LlamaTextGenerator.GetOrCreateShared(modelPath);
        AppDomain.CurrentDomain.ProcessExit += static (_, _) => LlamaTextGenerator.DisposeShared();
        
        if (args.Length > 0 && args[0] == "--extract-koujou")
        {
            var target = args.Length > 1 ? args[1] : "1";
            eratohoK.Cli.ExtractionHelper.RunDiagnostic(target);
            return;
        }

        var csvDirectory = args.Length > 0 ? args[0] : "../CSV";

        // Pre-load shop items
        if (Directory.Exists(csvDirectory))
        {
            using var csv = new CsvDataReader(csvDirectory);
            _shopItems = csv.ReadShopItems()
                .Where(i => i.Price > 0)
                .OrderBy(i => i.Price)
                .ToList();
        }
        if (_shopItems.Count == 0) _shopItems = BuildDemoShopItems();

        ShowTitle();

        while (true)
        {
            Console.WriteLine("[1] ニューゲーム");
            Console.WriteLine("[2] ロードゲーム");
            Console.WriteLine("[3] 終了");
            Console.Write("> ");
            switch (ReadLine())
            {
                case "1": RunNewGame(csvDirectory); break;
                case "2": RunLoadGame(csvDirectory); break;
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

    // ══════════════════════════════════════════════════════════════
    //  New Game
    // ══════════════════════════════════════════════════════════════
    static void RunNewGame(string csvDirectory)
    {
        Console.WriteLine();
        Console.WriteLine("データを読み込んでいます...");

        List<Character> characters = [];
        List<TrainDefinition> trainDefs = [];

        if (Directory.Exists(csvDirectory))
        {
            using var csv = new CsvDataReader(csvDirectory);
            characters = csv.LoadAllCharacters();
            trainDefs  = csv.ReadTrainDefinitions();
            Console.WriteLine($"  キャラクター {characters.Count} 人、" +
                              $"調教アクション {trainDefs.Count} 個を読み込みました。");
        }
        else
        {
            Console.WriteLine($"  警告: CSV ディレクトリが見つかりません ({csvDirectory})。デモデータを使用します。");
            characters = BuildDemoCharacters();
            trainDefs  = BuildDemoTrainDefs();
        }

        if (characters.Count == 0) { Console.WriteLine("キャラクターデータがありません。"); return; }

        // Scenario selection
        var scenarios = ScenarioLoader.GetBuiltInScenarios();
        Console.WriteLine();
        Console.WriteLine("── シナリオを選択 ──");
        for (int i = 0; i < scenarios.Count; i++)
            Console.WriteLine($"  [{i + 1}] {scenarios[i].Name} — {scenarios[i].Description}");
        Console.WriteLine("  [0] デフォルト（キャラデータ準拠）");
        Console.Write("> ");
        int scenarioIdx = -1;
        int.TryParse(ReadLine(), out scenarioIdx);

        var player = SelectCharacter(characters, "プレイヤーキャラクターを選択してください:");
        if (player == null) return;

        var targets = characters.Where(c => c.Id != player.Id).ToList();
        if (targets.Count == 0) { Console.WriteLine("調教できるキャラクターがいません。"); return; }

        var actionDefs  = trainDefs.Select(t => new TrainingActionDef(
            t.Id, t.Name, ActionType: t.ActionType)).ToList();
        var gameConfig  = new GameConfig();
        var router      = new CommandRoutingService(config: gameConfig);
        var trainEngine = new TrainingEngine(actionDefs, router);

        GameStateManager gameState;
        if (scenarioIdx >= 1 && scenarioIdx <= scenarios.Count)
            gameState = BuildGameStateFromScenario(characters, scenarios[scenarioIdx - 1]);
        else
            gameState = BuildGameState(characters);

        var playerCountry = gameState.GetCountry(gameState.PlayerCountryId);
        if (playerCountry != null) gameState.RecalcMaxShopTime(playerCountry);

        var slgEngine   = new SlgEngine(router);
        var gameEngine  = new GameEngine(gameState);
        gameEngine.StartGame();

        // Player-specific runtime state
        int  playerGold = 2000;
        var  inventory  = new PlayerInventory();
        int  day        = 1;

        Console.WriteLine();
        Console.WriteLine($"「{player.Name}」でゲームを開始します！（所持金: {playerGold} G）");
        Console.WriteLine();

        RunGameLoop(player, targets, trainEngine, gameState, slgEngine, gameEngine, gameConfig,
            ref day, ref playerGold, inventory, isNewGame: true);
    }

    // ══════════════════════════════════════════════════════════════
    //  Load Game
    // ══════════════════════════════════════════════════════════════
    static void RunLoadGame(string csvDirectory)
    {
        var saveList = Saves.ListSaves();
        if (saveList.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("セーブデータが見つかりません。");
            Console.WriteLine();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("── セーブデータを選択 ──");
        foreach (var (slot, data) in saveList)
        {
            Console.WriteLine($"  [スロット {slot}] Day {data.Day}  {data.CurrentDate:yyyy/MM/dd}  " +
                              $"所持金: {data.PlayerGold} G  ({data.SavedAt})");
        }
        Console.Write("スロット番号 > ");
        if (!int.TryParse(ReadLine(), out var chosen) || !Saves.HasSave(chosen))
        {
            Console.WriteLine("キャンセルしました。");
            Console.WriteLine();
            return;
        }

        var saveData = Saves.Load(chosen);
        if (saveData == null)
        {
            Console.WriteLine("ロードに失敗しました。");
            Console.WriteLine();
            return;
        }

        // Rebuild train defs
        List<TrainDefinition> trainDefs = [];
        if (Directory.Exists(csvDirectory))
        {
            using var csv = new CsvDataReader(csvDirectory);
            trainDefs = csv.ReadTrainDefinitions();
        }
        if (trainDefs.Count == 0) trainDefs = BuildDemoTrainDefs();

        var gameState = new GameStateManager();
        gameState.RestoreFromSaveData(saveData);

        var actionDefs  = trainDefs.Select(t => new TrainingActionDef(
            t.Id, t.Name, ActionType: t.ActionType)).ToList();
        var gameConfig  = new GameConfig();
        var router      = new CommandRoutingService(config: gameConfig);
        var trainEngine = new TrainingEngine(actionDefs, router);
        var slgEngine   = new SlgEngine(router);
        var gameEngine  = new GameEngine(gameState);
        gameEngine.StartGame();

        var player = gameState.GetCharacter(saveData.PlayerCharacterId);
        if (player == null)
        {
            Console.WriteLine("プレイヤーデータが壊れています。");
            Console.WriteLine();
            return;
        }

        var targets = saveData.TargetCharacterIds
            .Select(id => gameState.GetCharacter(id))
            .Where(c => c != null)
            .Cast<Character>()
            .ToList();

        if (targets.Count == 0)
            targets = gameState.GetAllCharacters().Where(c => c.Id != player.Id).ToList();

        var  inventory  = new PlayerInventory();
        foreach (var id in saveData.OwnedItemIds) inventory.AddItem(id);
        int  playerGold = saveData.PlayerGold;
        int  day        = saveData.Day;
        gameState.CurrentDate = saveData.CurrentDate;

        Console.WriteLine($"ロードしました。Day {day}  所持金: {playerGold} G");
        Console.WriteLine();

        RunGameLoop(player, targets, trainEngine, gameState, slgEngine, gameEngine, gameConfig,
            ref day, ref playerGold, inventory, isNewGame: false);
    }

    // ══════════════════════════════════════════════════════════════
    //  Main Game Loop
    // ══════════════════════════════════════════════════════════════
    static void RunGameLoop(
        Character player,
        List<Character> targets,
        TrainingEngine trainEngine,
        GameStateManager gameState,
        SlgEngine slgEngine,
        GameEngine gameEngine,
        GameConfig gameConfig,
        ref int day,
        ref int playerGold,
        PlayerInventory inventory,
        bool isNewGame)
    {
        var rng = Random.Shared;
        var targetIds = targets.Select(c => c.Id).ToList();

        while (true)
        {
            // ── Morning event ──────────────────────────────────────
            var morningEv = MorningEventSystem.FireMorningEvent(gameState, player, rng);
            if (morningEv != null)
                Console.WriteLine($"  ☀ {morningEv.Message}");

            // ── Win/Lose check ─────────────────────────────────────
            var endResult = CheckEndCondition(gameState, targets, day, player);
            if (endResult != null)
            {
                ShowEnding(endResult.Value, player, targets, day);
                return;
            }

            Console.WriteLine($"═══════════════════════════════════════");
            Console.WriteLine($"  Day {day,-4} [{gameState.CurrentDate:yyyy/MM/dd}]  " +
                              $"所持金: {playerGold,6} G  休息まで: {gameState.ShopTime}日");
            Console.WriteLine($"═══════════════════════════════════════");
            Console.WriteLine("[1] 調教");
            Console.WriteLine("[2] アイテムを使う");
            Console.WriteLine("[3] 商店");
            Console.WriteLine("[4] 休息 (次の日へ)");
            Console.WriteLine("[5] ステータス確認");
            Console.WriteLine("[6] セーブ");
            Console.WriteLine("[7] タイトルへ戻る");
            Console.Write("> ");

            switch (ReadLine())
            {
                case "1":
                    DoTraining(player, targets, trainEngine);
                    // Daily event after training
                    var trainDailyEv = DailyEventSystem.TryFireEvent(gameState, player, rng);
                    if (trainDailyEv != null)
                    {
                        Console.WriteLine($"  📅 【{trainDailyEv.EventName}】{trainDailyEv.Message}");
                        foreach (var d in trainDailyEv.Details) Console.WriteLine($"    {d}");
                        Console.WriteLine();
                    }
                    break;

                case "2":
                    DoUseItem(player, targets, inventory);
                    break;

                case "3":
                    DoShop(ref playerGold, inventory);
                    break;

                case "4":
                    // Rest: advance day, gain gold
                    gameState.AdvanceTurn();
                    playerGold += GoldPerDay;
                    day++;
                    gameState.ShopTime--;
                    Console.WriteLine($"  休息しました。Day {day}。(所持金 +{GoldPerDay} G)");

                    // TurnEnd processing
                    var turnResult = TurnEndProcessor.ProcessTurnEnd(gameState, gameConfig, rng);
                    playerGold += turnResult.GoldGained;
                    if (turnResult.GoldGained > 0)
                        Console.WriteLine($"  都市収入: +{turnResult.GoldGained} G");
                    foreach (var ev in turnResult.Events)
                        Console.WriteLine($"  ⚡ {ev}");
                    Console.WriteLine();

                    // Daily event on rest
                    var dailyEv = DailyEventSystem.TryFireEvent(gameState, player, rng);
                    if (dailyEv != null)
                    {
                        Console.WriteLine($"  📅 【{dailyEv.EventName}】{dailyEv.Message}");
                        foreach (var d in dailyEv.Details) Console.WriteLine($"    {d}");
                        Console.WriteLine();
                    }

                    if (gameState.ShopTime <= 0)
                    {
                        gameState.ShopTime = gameState.MaxShopTime;
                        var warResult = ShowSlgPhase(gameState, slgEngine, player, ref playerGold);
                        if (warResult == EndReason.PlayerDestroyed)
                        {
                            ShowEnding(EndReason.PlayerDestroyed, player, targets, day);
                            return;
                        }
                    }
                    break;

                case "5":
                    ShowStatus(player, targets);
                    break;

                case "6":
                    DoSave(gameState, player, targets, day, playerGold, inventory);
                    break;

                case "7":
                    Console.WriteLine();
                    return;

                default:
                    Console.WriteLine("無効な入力です。");
                    Console.WriteLine();
                    break;
            }
        }
    }

    // ══════════════════════════════════════════════════════════════
    //  Training
    // ══════════════════════════════════════════════════════════════
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
        int shown = Math.Min(engine.AvailableActions.Count, MaxDisplayedActions);
        for (int i = 0; i < shown; i++)
        {
            var a = engine.AvailableActions[i];
            Console.WriteLine($"  [{i,2}] {a.Name,-12} ({a.TimeRequired,2}分) [{a.ActionType}]");
        }
        Console.Write("> ");
        var input = ReadLine();
        if (!int.TryParse(input, out var idx) || idx < 0 || idx >= shown)
        {
            Console.WriteLine("  キャンセルしました。"); Console.WriteLine(); return;
        }

        var session = engine.CreateSession(player.Id, target.Id);
        var result  = engine.ExecuteAction(session, player, target, engine.AvailableActions[idx].Id);

        Console.WriteLine();
        if (result.Success)
        {
            Console.WriteLine($"  ★【{result.ActionName}】を実行しました。");

            // Character reaction
            string reaction = result.SemanticEvent is not null
                ? ReactionSystem.GetCharacterReactionAsync(result.SemanticEvent).GetAwaiter().GetResult()
                : ReactionSystem.GetCharacterReactionAsync(target, engine.AvailableActions[idx].ActionType).GetAwaiter().GetResult();
            reaction = TrimDialogueBrackets(reaction);
            Console.WriteLine($"  {target.Name}:「{reaction}」");
            Console.WriteLine();

            if (result.StatChanges != null && result.StatChanges.Any(kv => kv.Value != 0))
            {
                Console.WriteLine("  ── ステータス変化 ──");
                foreach (var kv in result.StatChanges.Where(kv => kv.Value != 0))
                    Console.WriteLine($"    {kv.Key}: {(kv.Value >= 0 ? "+" : "")}{kv.Value}");
            }

            if (result.SourceDelta != null)
            {
                Console.WriteLine("  ── SOURCE 蓄積 ──");
                Console.WriteLine($"    快感:{result.SourceDelta.Pleasure}  " +
                                  $"愛情:{result.SourceDelta.Love}  " +
                                  $"屈辱:{result.SourceDelta.Humiliation}  " +
                                  $"痛苦:{result.SourceDelta.Pain}");
            }

            var finalChanges = engine.FinalizeSession(session, target);
            if (finalChanges.Any(kv => kv.Value != 0))
            {
                Console.WriteLine("  ── SOURCE 最終適用 ──");
                foreach (var kv in finalChanges.Where(kv => kv.Value != 0))
                    Console.WriteLine($"    {kv.Key}: {(kv.Value >= 0 ? "+" : "")}{kv.Value}");
            }

            // Milestone checks
            CheckMilestones(target);
        }
        else
        {
            Console.WriteLine($"  [{result.ActionName}] 失敗: {result.Message}");
        }

        Console.WriteLine($"  使用時間: {session.TimeUsed} 分");

        // Session-end reaction
        string endReaction = ReactionSystem.GetSessionEndReactionAsync(target).GetAwaiter().GetResult();
        Console.WriteLine($"  {target.Name}: {endReaction}");

        Console.WriteLine();
        Console.Write("  [Enter で続ける] ");
        ReadLine();
        Console.WriteLine();
    }

    static void CheckMilestones(Character target)
    {
        // Relationship milestones based on obedience / likeability
        if (!target.IsInLove && target.BaseStatus.Obedience >= 300
            && target.GetLikeabilityTowards(0) >= 30)
        {
            target.IsInLove = true;
            Console.WriteLine();
            Console.WriteLine($"  ★★ {target.Name} が恋慕状態になった！");
            Console.WriteLine($"  {target.Name}: {ReactionSystem.GetFirstTimeReactionAsync(target, "恋慕").GetAwaiter().GetResult()}");
        }
        if (!target.IsLover && target.IsInLove && target.BaseStatus.Obedience >= 600)
        {
            target.IsLover = true;
            Console.WriteLine();
            Console.WriteLine($"  ★★★ {target.Name} が恋人になった！");
            Console.WriteLine($"  {target.Name}: {ReactionSystem.GetFirstTimeReactionAsync(target, "恋人").GetAwaiter().GetResult()}");
        }
    }

    // ══════════════════════════════════════════════════════════════
    //  Shop
    // ══════════════════════════════════════════════════════════════
    static void DoShop(ref int playerGold, PlayerInventory inventory)
    {
        Console.WriteLine();
        Console.WriteLine($"╔══════════════════════════════════════╗");
        Console.WriteLine($"║  商 店  (所持金: {playerGold,6} G)            ║");
        Console.WriteLine($"╚══════════════════════════════════════╝");

        var affordable = _shopItems.Where(i => i.Price > 0).ToList();
        int shown = Math.Min(affordable.Count, ShopMaxDisplay);
        for (int i = 0; i < shown; i++)
        {
            var item = affordable[i];
            int owned = inventory.GetCount(item.Id);
            string ownedStr = owned > 0 ? $" (所持:{owned})" : "";
            Console.WriteLine($"  [{i,2}] {item.Name,-14} {item.Price,6} G{ownedStr}");
        }
        Console.WriteLine("  [q] 終了");
        Console.Write("> ");

        var input = ReadLine();
        if (input == "q" || input == "") { Console.WriteLine(); return; }

        if (!int.TryParse(input, out var idx) || idx < 0 || idx >= shown)
        {
            Console.WriteLine("  キャンセルしました。"); Console.WriteLine(); return;
        }

        var selected = affordable[idx];
        if (playerGold < selected.Price)
        {
            Console.WriteLine($"  所持金が足りません。({selected.Price} G 必要、所持: {playerGold} G)");
        }
        else
        {
            playerGold -= selected.Price;
            inventory.AddItem(selected.Id);
            Console.WriteLine($"  {selected.Name} を購入しました。(残金: {playerGold} G)");
        }
        Console.WriteLine();
    }

    static void DoUseItem(Character player, List<Character> targets, PlayerInventory inventory)
    {
        var owned = _shopItems.Where(i => inventory.HasItem(i.Id)).ToList();
        if (owned.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("  所持アイテムがありません。商店で購入してください。");
            Console.WriteLine();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("── 使用するアイテムを選択 ──");
        for (int i = 0; i < owned.Count; i++)
        {
            var it = owned[i];
            Console.WriteLine($"  [{i}] {it.Name} x{inventory.GetCount(it.Id)}");
        }
        Console.Write("> ");
        if (!int.TryParse(ReadLine(), out var idx) || idx < 0 || idx >= owned.Count)
        {
            Console.WriteLine("  キャンセルしました。"); Console.WriteLine(); return;
        }

        var item = owned[idx];
        var target = SelectCharacter(targets, "使用対象を選択:");
        if (target == null) return;

        if (!inventory.UseItem(item.Id))
        {
            Console.WriteLine("  使用に失敗しました。"); Console.WriteLine(); return;
        }

        // Apply item effect: boost Joy / Obedience based on item category
        int bonusJoy = 0, bonusObed = 0;
        string effect = "";
        var rng = Random.Shared;
        if (item.Id == 284) // 再生の秘薬
        {
            effect = "烙印を消去、処女を再生し、感度関係のABL／EXPを0にリセットしました。";
            target.Talent = target.Talent with { IsVirgin = true, IsMaleVirgin = true, IsAnalVirgin = true };
            target.Experience = new Experience(); // Exp reset
            target.Ability = target.Ability with { SexualKnowledge = 0, Dominance = 0, Masochism = 0, Desire = 0 }; // Abl reset
        }
        else if (item.Id is >= 70 and <= 79)   // drugs / 媚薬 range
        {
            bonusJoy  = 50 + rng.Next(30);
            bonusObed = 20 + rng.Next(20);
            effect = $"媚薬効果: 快感+{bonusJoy}  服従+{bonusObed}";
        }
        else if (item.Id is >= 150 and <= 159) // 酒
        {
            bonusJoy  = 30 + rng.Next(20);
            effect = $"酒酔い効果: 快感+{bonusJoy}";
        }
        else
        {
            bonusObed = 15;
            effect = $"アイテム効果: 服従+{bonusObed}";
        }

        target.BaseStatus = target.BaseStatus with
        {
            Joy       = Math.Clamp(target.BaseStatus.Joy + bonusJoy, 0, 1000),
            Obedience = Math.Clamp(target.BaseStatus.Obedience + bonusObed, 0, 1000)
        };

        Console.WriteLine($"  {target.Name} に {item.Name} を使用しました。");
        Console.WriteLine($"  {effect}");
        Console.WriteLine();
    }

    // ══════════════════════════════════════════════════════════════
    //  SLG Phase
    // ══════════════════════════════════════════════════════════════
    static EndReason? ShowSlgPhase(GameStateManager gameState, SlgEngine slgEngine,
        Character player, ref int playerGold)
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║          SLG フェーズ                ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();

        // Player action
        DoPlayerSlgAction(gameState, slgEngine, player, ref playerGold);

        // AI acts
        Console.WriteLine("── AI 勢力の行動 ──");
        var logs = slgEngine.ExecuteAllAiActions(gameState.GetAllCountries(), gameState.GetAllCities());
        if (logs.Count == 0)
            Console.WriteLine("  AI 勢力の行動はありませんでした。");
        else
            foreach (var entry in logs) Console.WriteLine(entry);

        // Check if player country was destroyed
        var playerCountry = gameState.GetCountry(gameState.PlayerCountryId);
        if (playerCountry != null && playerCountry.IsDestroyed)
            return EndReason.PlayerDestroyed;

        // Random AI war events
        ProcessAiWars(gameState);

        Console.WriteLine();
        Console.Write("[Enter で続ける]");
        ReadLine();
        Console.WriteLine();
        return null;
    }

    static void DoPlayerSlgAction(GameStateManager gameState, SlgEngine slgEngine,
        Character player, ref int playerGold)
    {
        var allCountries = gameState.GetAllCountries().ToList();
        var allCities    = gameState.GetAllCities().ToList();
        var playerCountry = gameState.GetCountry(gameState.PlayerCountryId);

        if (playerCountry == null) return;

        Console.WriteLine("── プレイヤーの行動 ──");
        Console.WriteLine("[1] 内政 (資金増加)");
        Console.WriteLine("[2] 外交 (関係改善)");
        Console.WriteLine("[3] 宣戦布告");
        Console.WriteLine("[4] 徴兵");
        Console.WriteLine("[5] スキップ");
        Console.WriteLine("[6] 部隊管理");
        Console.WriteLine("[7] 技術研究");
        Console.WriteLine("[8] 外交調教提案");
        Console.Write("> ");

        switch (ReadLine())
        {
            case "1": // Internal work
            {
                int gain = playerCountry.EconomyScale * 2 + 500;
                playerGold += gain;
                playerCountry.EconomyScale += 5;
                Console.WriteLine($"  内政を実施しました。資金 +{gain} G。(合計: {playerGold} G)");
                Console.WriteLine();
                break;
            }
            case "2": // Diplomacy
            {
                var others = allCountries.Where(c => c.Id != playerCountry.Id && !c.IsDestroyed).ToList();
                if (others.Count == 0) { Console.WriteLine("  外交相手がいません。"); break; }
                Console.WriteLine("  外交相手を選択:");
                for (int i = 0; i < others.Count; i++)
                    Console.WriteLine($"    [{i}] {others[i].Name}  兵数: {others[i].SoldierCount}");
                Console.Write("  > ");
                if (int.TryParse(ReadLine(), out var di) && di >= 0 && di < others.Count)
                {
                    Console.WriteLine($"  {others[di].Name} との外交を強化しました。");
                }
                Console.WriteLine();
                break;
            }
            case "3": // Declare War
            {
                var enemies = allCountries.Where(c => c.Id != playerCountry.Id && !c.IsDestroyed).ToList();
                if (enemies.Count == 0) { Console.WriteLine("  攻撃できる勢力がいません。"); break; }
                Console.WriteLine("  攻撃対象を選択:");
                for (int i = 0; i < enemies.Count; i++)
                    Console.WriteLine($"    [{i}] {enemies[i].Name}  兵数: {enemies[i].SoldierCount}");
                Console.Write("  > ");
                if (!int.TryParse(ReadLine(), out var ei) || ei < 0 || ei >= enemies.Count)
                {
                    Console.WriteLine("  キャンセルしました。"); break;
                }
                var target = enemies[ei];
                var targetCities = allCities.Where(c => c.CountryId == target.Id).ToList();
                if (targetCities.Count == 0) { Console.WriteLine("  攻撃できる都市がありません。"); break; }

                Console.WriteLine("  攻略する都市を選択:");
                for (int i = 0; i < targetCities.Count; i++)
                    Console.WriteLine($"    [{i}] {targetCities[i].Name}  防御: {targetCities[i].Defense}");
                Console.Write("  > ");
                if (!int.TryParse(ReadLine(), out var ci) || ci < 0 || ci >= targetCities.Count)
                {
                    Console.WriteLine("  キャンセルしました。"); break;
                }

                if (playerCountry.SoldierCount < 10)
                {
                    Console.WriteLine("  兵士が足りません（最低10人必要）。"); break;
                }

                var result = BattleEng.ResolveSiege(playerCountry, target, targetCities[ci]);
                Console.WriteLine();
                Console.WriteLine("  ── 攻城戦結果 ──");
                PrintBattleResult(result, gameState);
                Console.WriteLine();
                break;
            }
            case "4": // Recruit soldiers
            {
                int cost = 100;
                int recruit = 20;
                if (playerGold < cost)
                {
                    Console.WriteLine($"  資金が足りません（{cost} G 必要）。"); break;
                }
                playerGold -= cost;
                playerCountry.SoldierCount += recruit;
                Console.WriteLine($"  兵士を徴兵しました。+{recruit} 人 (合計: {playerCountry.SoldierCount} 人)  " +
                                  $"資金: {playerGold} G");
                Console.WriteLine();
                break;
            }
            case "6": // Unit management
            {
                var units = gameState.GetUnitsForCountry(playerCountry.Id);
                Console.WriteLine($"  保有部隊: {units.Count} / 10");
                foreach (var u in units)
                    Console.WriteLine($"    [{u.Id}] {u.Name}  兵数:{u.SoldierCount}  位置:{u.Position}");
                Console.WriteLine("  [n] 新規部隊を編成  [q] 戻る");
                Console.Write("  > ");
                var unitInput = ReadLine();
                if (unitInput == "n")
                {
                    int newId = units.Count > 0 ? units.Max(u => u.Id) + 1 : 1;
                    var newUnit = new MilitaryUnit
                    {
                        Id = newId, Name = $"{playerCountry.Name}第{newId}軍",
                        CountryId = playerCountry.Id,
                        SoldierCount = Math.Min(10, playerCountry.SoldierCount)
                    };
                    gameState.AddUnit(newUnit);
                    Console.WriteLine($"  {newUnit.Name} を編成しました。");
                }
                Console.WriteLine();
                break;
            }
            case "7": // Tech research
            {
                var techDescs = TechSystem.GetAllTechDescriptions();
                Console.WriteLine("  ── 利用可能な技術 ──");
                var available = techDescs.Keys.Where(t => TechSystem.CanResearch(playerCountry, t)).ToList();
                if (available.Count == 0)
                {
                    Console.WriteLine("  研究できる技術がありません。");
                }
                else
                {
                    for (int i = 0; i < available.Count; i++)
                        Console.WriteLine($"    [{i}] {techDescs[available[i]]}");
                    Console.Write("  > ");
                    if (int.TryParse(ReadLine(), out var ti) && ti >= 0 && ti < available.Count)
                    {
                        TechSystem.Research(playerCountry, available[ti]);
                        Console.WriteLine($"  【{available[ti]}】を研究しました！");
                    }
                    else
                    {
                        Console.WriteLine("  キャンセルしました。");
                    }
                }
                Console.WriteLine();
                break;
            }
            case "8": // Diplomacy training proposal
            {
                var rng = Random.Shared;
                var enemies = allCountries.Where(c => c.Id != playerCountry.Id && !c.IsDestroyed).ToList();
                if (enemies.Count == 0) { Console.WriteLine("  外交相手がいません。"); break; }
                Console.WriteLine("  外交調教を提案する勢力を選択:");
                for (int i = 0; i < enemies.Count; i++)
                    Console.WriteLine($"    [{i}] {enemies[i].Name}");
                Console.Write("  > ");
                if (!int.TryParse(ReadLine(), out var dti) || dti < 0 || dti >= enemies.Count)
                {
                    Console.WriteLine("  キャンセルしました。"); break;
                }
                var targetCountry = enemies[dti];
                var targetChars = gameState.GetCharactersByCountry(targetCountry.Id);
                if (targetChars.Count == 0) { Console.WriteLine("  対象キャラクターがいません。"); break; }
                var targetChar = targetChars[rng.Next(targetChars.Count)];
                var dipResult = gameState.DiplomacySystem.ProposeTraining(
                    playerCountry, targetCountry, targetChar, slgEngine, rng);
                Console.WriteLine($"  {dipResult.Message}");
                Console.WriteLine();
                break;
            }
            default:
                Console.WriteLine("  行動をスキップしました。");
                Console.WriteLine();
                break;
        }
    }

    static void ProcessAiWars(GameStateManager gameState)
    {
        var rng = Random.Shared;
        var allCountries = gameState.GetAllCountries().Where(c => !c.IsDestroyed).ToList();
        var allCities    = gameState.GetAllCities().ToList();

        foreach (var attacker in allCountries.Where(c => c.IsAIControlled))
        {
            if (rng.NextDouble() > 0.4) continue; // 40% chance of attacking

            var enemies = allCountries.Where(c => c.Id != attacker.Id && !c.IsDestroyed).ToList();
            if (enemies.Count == 0) continue;

            var defender = enemies[rng.Next(enemies.Count)];
            var cities = allCities.Where(c => c.CountryId == defender.Id).ToList();
            if (cities.Count == 0 || attacker.SoldierCount < 5) continue;

            var city = cities[rng.Next(cities.Count)];
            var result = BattleEng.ResolveSiege(attacker, defender, city);
            PrintBattleResult(result, gameState);
        }
    }

    static void PrintBattleResult(BattleResult r, GameStateManager? gameState = null)
    {
        string outcome = r.AttackerWon ? "陥落！" : "防衛成功";
        Console.WriteLine($"  [{r.AttackerName}] → [{r.CityName}({r.DefenderName})] : {outcome}");
        Console.WriteLine($"    攻撃側損失: {r.AttackerLoss}  防衛側損失: {r.DefenderLoss}  ({r.RoundsPlayed}ラウンド)");
        if (r.AttackerWon && r.Plunder > 0)
            Console.WriteLine($"    略奪: {r.Plunder} G");
        if (r.DefenderDestroyed)
            Console.WriteLine($"  ★ {r.DefenderName} が滅亡しました！");
        if (r.CapturedCharacterId.HasValue && gameState != null)
        {
            gameState.CaptureCharacter(r.CapturedCharacterId.Value, gameState.PlayerCountryId);
            var captured = gameState.GetCharacter(r.CapturedCharacterId.Value);
            if (captured != null)
                Console.WriteLine($"  ★ {captured.Name} を捕虜にした！");
        }
        if (r.RoundLog != null && r.RoundLog.Count > 0)
        {
            foreach (var line in r.RoundLog)
                Console.WriteLine(line);
        }
    }

    // ══════════════════════════════════════════════════════════════
    //  Save
    // ══════════════════════════════════════════════════════════════
    static void DoSave(GameStateManager gameState, Character player, List<Character> targets,
        int day, int gold, PlayerInventory inventory)
    {
        Console.WriteLine();
        Console.WriteLine("── セーブスロットを選択 (0-4) ──");

        var existing = Saves.ListSaves();
        foreach (var (slot, data) in existing)
            Console.WriteLine($"  [スロット {slot}] Day {data.Day}  ({data.SavedAt})");

        Console.Write("スロット番号 > ");
        if (!int.TryParse(ReadLine(), out var chosen) || chosen < 0 || chosen > 4)
        {
            Console.WriteLine("  キャンセルしました。"); Console.WriteLine(); return;
        }

        var itemIds = inventory.Items.SelectMany(kv =>
            Enumerable.Repeat(kv.Key, kv.Value)).ToList();

        var saveData = gameState.CreateSaveData(
            day, player.Id, targets.Select(c => c.Id).ToList(), gold, itemIds);

        bool ok = Saves.Save(saveData, chosen);
        Console.WriteLine(ok ? $"  スロット {chosen} にセーブしました。" : "  セーブに失敗しました。");
        Console.WriteLine();
    }

    // ══════════════════════════════════════════════════════════════
    //  Status
    // ══════════════════════════════════════════════════════════════
    static void ShowStatus(Character player, List<Character> targets)
    {
        Console.WriteLine();
        Console.WriteLine("── ステータス確認 ──");
        var target = SelectCharacter(targets, "確認するキャラクターを選択:");
        if (target == null) return;

        Console.WriteLine();
        Console.WriteLine($"  名前      : {target.Name} ({target.Nickname})");
        Console.WriteLine($"  性別      : {target.Gender}");
        Console.WriteLine($"  体力      : {target.BaseStatus.Physical}");
        Console.WriteLine($"  気力      : {target.BaseStatus.Mental}");
        Console.WriteLine($"  服従度    : {target.BaseStatus.Obedience}");
        Console.WriteLine($"  堕落度    : {target.BaseStatus.Corruption}");
        Console.WriteLine($"  反抗心    : {target.BaseStatus.Resistance}");
        Console.WriteLine($"  愉悦      : {target.BaseStatus.Joy}");
        Console.WriteLine($"  屈辱      : {target.BaseStatus.Humiliation}");
        Console.WriteLine($"  恐怖      : {target.BaseStatus.Fear}");
        Console.WriteLine($"  武闘      : {target.Ability.Fight}");
        Console.WriteLine($"  知略      : {target.Ability.Intelligence}");
        Console.WriteLine($"  政治      : {target.Ability.Politics}");
        Console.WriteLine($"  好感度    : {target.GetLikeabilityTowards(player.Id)}");
        Console.WriteLine($"  恋慕      : {(target.IsInLove ? "あり" : "なし")}");
        Console.WriteLine($"  恋人      : {(target.IsLover ? "あり" : "なし")}");
        string talentTags = string.Join(" ", new[]
        {
            (target.Talent.IsVirgin && target.Gender != Gender.Male)     ? "[処女]"      : null,
            (target.Talent.IsAnalVirgin && target.Gender != Gender.Male) ? "[A処女]"     : null,
            target.Talent.IsRebellious  ? "[反抗的]"    : null,
            target.Talent.IsHonest      ? "[素直]"      : null,
            target.Talent.IsStoic       ? "[気丈]"      : null,
            target.Talent.IsTsundere    ? "[ツンデレ]"  : null,
            target.Talent.IsEasilyWet   ? "[濡れやすい]": null,
            target.Talent.IsWeakToPain  ? "[痛みに弱]"  : null
        }.Where(t => t != null));
        if (talentTags.Length > 0) Console.WriteLine($"  素質      : {talentTags}");
        Console.WriteLine();
    }

    // ══════════════════════════════════════════════════════════════
    //  Win / Lose
    // ══════════════════════════════════════════════════════════════
    static EndReason? CheckEndCondition(GameStateManager gameState,
        List<Character> targets, int day, Character player)
    {
        // Turn limit
        if (day > TurnLimit)
            return EndReason.TurnLimit;

        // Player country destroyed?
        var playerCountry = gameState.GetCountry(gameState.PlayerCountryId);
        if (playerCountry != null && playerCountry.IsDestroyed)
            return EndReason.PlayerDestroyed;

        // Conquer all factions
        var allCountries = gameState.GetAllCountries().Where(c => !c.IsDestroyed).ToList();
        if (allCountries.All(c => c.Id == gameState.PlayerCountryId || c.IsDestroyed))
            return EndReason.AllConquered;

        // Perfect ending: all targets at high obedience
        if (targets.Count > 0 && targets.All(t => t.BaseStatus.Obedience >= ObedienceWinThresh)
            && allCountries.All(c => c.Id == gameState.PlayerCountryId || c.IsDestroyed))
            return EndReason.PerfectEnd;

        return null;
    }

    static void ShowEnding(EndReason reason, Character player, List<Character> targets, int day)
    {
        Console.WriteLine();
        Console.WriteLine();

        switch (reason)
        {
            case EndReason.AllConquered:
            case EndReason.PerfectEnd:
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine("║            ★ 真・エンディング ★             ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine($"  {day} 日間の戦いの末、{player.Name} はすべての勢力を支配下に置いた。");
                Console.WriteLine();
                foreach (var t in targets)
                {
                    string rel = t.IsLover ? "恋人" : t.IsInLove ? "恋慕" :
                                 t.BaseStatus.Obedience > 500 ? "忠実な下僕" : "従属";
                    Console.WriteLine($"  {t.Name} は{rel}として、{player.Name} の傍にいる。");
                }
                Console.WriteLine();
                Console.WriteLine("  ─────────────── E N D ───────────────");
                break;

            case EndReason.TurnLimit:
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine("║          ゲームオーバー（時間切れ）          ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine($"  {TurnLimit} 日が経過した。物語は未完のまま幕を閉じた。");
                int conquered = targets.Count(t => t.BaseStatus.Obedience >= ObedienceWinThresh);
                Console.WriteLine($"  調教達成: {conquered}/{targets.Count}");
                Console.WriteLine();
                Console.WriteLine("  ─────────────── G A M E  O V E R ───────────────");
                break;

            case EndReason.PlayerDestroyed:
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine("║          ゲームオーバー（勢力滅亡）          ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine($"  {player.Name} の勢力は滅亡した...");
                Console.WriteLine();
                Console.WriteLine("  ─────────────── G A M E  O V E R ───────────────");
                break;
        }

        Console.WriteLine();
        Console.Write("[Enter でタイトルへ]");
        ReadLine();
        Console.WriteLine();
    }

    // ══════════════════════════════════════════════════════════════
    //  Helpers
    // ══════════════════════════════════════════════════════════════
    static void ShowTitle()
    {
        Console.WriteLine();
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║   eratohoK Reborn  (.NET 10 Refactored v2.0)  ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");
        Console.WriteLine();
    }

    static Character? SelectCharacter(List<Character> characters, string prompt)
    {
        Console.WriteLine();
        Console.WriteLine(prompt);
        int shown = Math.Min(characters.Count, MaxDisplayedChars);
        for (int i = 0; i < shown; i++)
        {
            var c = characters[i];
            var tags = string.Join("/", new[]
            {
                (c.Talent.IsVirgin && c.Gender != Gender.Male) ? "処女" : null,
                c.Talent.IsOptimistic ? "楽観的" : null,
                c.IsLover             ? "恋人"   : null,
                c.IsInLove            ? "恋慕"   : null
            }.Where(t => t != null));
            string tagStr = tags.Length > 0 ? $" [{tags}]" : "";
            Console.WriteLine($"  [{i}] {c.Name}{tagStr}");
        }
        if (characters.Count > shown) Console.WriteLine($"  ...他 {characters.Count - shown} 人");
        Console.Write("> ");
        var input = ReadLine();
        if (!int.TryParse(input, out var idx) || idx < 0 || idx >= shown)
        {
            Console.WriteLine("  キャンセルしました。"); Console.WriteLine(); return null;
        }
        return characters[idx];
    }

    static string ReadLine() => Console.ReadLine() ?? "";

    static string TrimDialogueBrackets(string text)
    {
        if (text.StartsWith('「') && text.EndsWith('」') && text.Length >= 2)
        {
            return text[1..^1];
        }

        return text;
    }

    // ══════════════════════════════════════════════════════════════
    //  Game state builder
    // ══════════════════════════════════════════════════════════════
    static GameStateManager BuildGameState(List<Character> characters)
    {
        var gs = new GameStateManager();
        foreach (var c in characters) gs.AddCharacter(c);

        // Build countries from characters (simple heuristic: assign to existing factions)
        var player = new Country { Id = 1, Name = "博麗神社", BossCharacterId = 1,
            EconomyScale = 300, SoldierCount = 50, IsAIControlled = false };
        var c2 = new Country { Id = 2, Name = "霧の湖", BossCharacterId = 2,
            EconomyScale = 200, SoldierCount = 30, IsAIControlled = true };
        var c3 = new Country { Id = 3, Name = "紅魔館", BossCharacterId = 3,
            EconomyScale = 500, SoldierCount = 100, IsAIControlled = true };
        gs.AddCountry(player); gs.AddCountry(c2); gs.AddCountry(c3);

        gs.AddCity(new City { Id = 1, Name = "博麗神社", CountryId = 1,
            Population = 50, Gold = 1000, Defense = 100 });
        gs.AddCity(new City { Id = 2, Name = "霧の湖", CountryId = 2,
            Population = 30, Gold = 800, Defense = 80 });
        gs.AddCity(new City { Id = 3, Name = "紅魔館", CountryId = 3,
            Population = 100, Gold = 5000, Defense = 300 });

        player.CityIds.Add(1);
        c2.CityIds.Add(2);
        c3.CityIds.Add(3);

        gs.PlayerCountryId = 1;
        return gs;
    }

    static GameStateManager BuildGameStateFromScenario(List<Character> characters, ScenarioDefinition scenario)
    {
        var gs = new GameStateManager();
        foreach (var c in characters) gs.AddCharacter(c);

        for (int i = 0; i < scenario.Factions.Count; i++)
        {
            var faction = scenario.Factions[i];
            int id = i + 1;
            var country = new Country
            {
                Id = id,
                Name = faction.Name,
                EconomyScale = faction.EconomyScale,
                SoldierCount = faction.SoldierCount,
                IsAIControlled = i != 0
            };
            foreach (var tech in faction.StartingTechs)
                country.ResearchTechnology(tech);
            gs.AddCountry(country);

            var city = new City
            {
                Id = id,
                Name = faction.Name,
                CountryId = id,
                Population = faction.EconomyScale / 6,
                Gold = faction.EconomyScale * 3,
                Defense = faction.SoldierCount * 2
            };
            gs.AddCity(city);
            country.CityIds.Add(id);
        }

        gs.PlayerCountryId = 1;
        return gs;
    }

    // ── Demo data ──────────────────────────────────────────────────
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
        new(0, "愛撫", TrainDefinition.InferActionType(0)),
        new(1, "胸愛撫", TrainDefinition.InferActionType(1)),
        new(2, "クンニ", TrainDefinition.InferActionType(2)),
        new(3, "指挿入れ", TrainDefinition.InferActionType(3)),
        new(4, "アナル愛撫", TrainDefinition.InferActionType(4)),
        new(20, "キス", TrainDefinition.InferActionType(20)),
        new(30, "正常位", TrainDefinition.InferActionType(30)),
        new(80, "脅す", TrainDefinition.InferActionType(80)),
        new(71, "媚薬", TrainDefinition.InferActionType(71))
    ];

    static List<ShopItem> BuildDemoShopItems() =>
    [
        new(160, "ローション",   200),
        new(162, "コンドーム",   800),
        new(110, "鞭",         2000),
        new(71,  "媚薬",       20000),
        new(151, "清酒",        1000),
        new(200, "ローター",    6000),
        new(284, "再生の秘薬",  200000)
    ];
}

/// <summary>ゲーム終了理由</summary>
public enum EndReason
{
    AllConquered,    // すべての勢力を制圧
    PerfectEnd,      // 完全エンディング
    TurnLimit,       // ターン制限超過
    PlayerDestroyed  // プレイヤー勢力滅亡
}

