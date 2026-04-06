namespace eratohoK.Cli;

using eratohoK.Core;
using eratohoK.Data;
using eratohoK.Semantics;
using eratohoK.GameEngine;

/// <summary>
/// プログラムエントリーポイント
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("eratohoK Reborn - .NET 10 Refactored Version");
        Console.WriteLine("=============================================");
        Console.WriteLine();
        
        // CSV ディレクトリの設定
        var csvDirectory = args.Length > 0 ? args[0] : "../CSV";
        
        if (!Directory.Exists(csvDirectory))
        {
            Console.WriteLine($"Error: CSV directory not found: {csvDirectory}");
            return;
        }
        
        // CSV データリーダーを初期化
        using var csvReader = new CsvDataReader(csvDirectory);
        
        // 素質定義を読み込み
        Console.WriteLine("Loading Talent definitions...");
        var talentDefs = csvReader.ReadTalentDefinitions();
        Console.WriteLine($"Loaded {talentDefs.Count} talent definitions.");
        
        // 調教定義を読み込み
        Console.WriteLine("Loading Train definitions...");
        var trainDefs = csvReader.ReadTrainDefinitions();
        Console.WriteLine($"Loaded {trainDefs.Count} train definitions.");
        
        // セマンティックテキストファクトリーを初期化
        var semanticFactory = new SemanticTextFactory(csvReader);
        
        // ゲーム状態マネージャーを初期化
        var gameState = new GameStateManager();
        var gameEngine = new GameEngine.GameEngine(gameState);
        
        // テストキャラクターを作成
        var testCharacter = new Character
        {
            Id = 1,
            No = 1,
            Name = "霊夢",
            Nickname = "博麗の巫女",
            Gender = Gender.Female,
            CountryId = 1,
            CityId = 1,
            BaseStatus = new BaseStatus(Physical: 100, Mental: 100),
            Talent = new Talent(Gender: Gender.Female, IsVirgin: true),
            Likeability = 50,
            Subordination = 30
        };
        
        gameState.AddCharacter(testCharacter);
        
        // テスト勢力を作成
        var testCountry = new Country
        {
            Id = 1,
            Name = "博麗神社",
            Description = "幻想郷の神社",
            BossCharacterId = 1,
            Color = "#FF0000"
        };
        
        gameState.AddCountry(testCountry);
        
        // テスト都市を作成
        var testCity = new City
        {
            Id = 1,
            Name = "博麗神社",
            Description = "博麗神社の本殿",
            CountryId = 1,
            Defense = 100,
            Population = 10
        };
        
        gameState.AddCity(testCity);
        
        Console.WriteLine();
        Console.WriteLine("Test character created:");
        Console.WriteLine($"  Name: {testCharacter.Name}");
        Console.WriteLine($"  Gender: {testCharacter.Talent.Gender}");
        Console.WriteLine($"  HP: {testCharacter.BaseStatus.Physical}");
        Console.WriteLine($"  MP: {testCharacter.BaseStatus.Mental}");
        
        // セマンティックテキストのデモ
        Console.WriteLine();
        Console.WriteLine("Semantic Text Demo:");
        
        var sampleTexts = new List<string>
        {
            "おはようございます、今日も元気ですね！",
            "ありがとう、感謝します。",
            "ごめんなさい、謝罪いたします。",
            "嬉しい！楽しい気分です。",
            "怒り狂っています！",
            "悲しい...泣きたい気分です。",
            "怖い...恐ろしいです。",
            "朝になりました、起床しましょう。",
            "夜になりました、就寝しましょう。",
            "調教を開始します。",
            "快感を感じています。",
            "痛い...苦痛です。"
        };
        
        var decomposedTexts = semanticFactory.DecomposeToBasicSemantics(sampleTexts);
        
        foreach (var text in decomposedTexts)
        {
            Console.WriteLine($"  [{text.SemanticCategory}] {text.Name}");
        }
        
        // LLM プロンプト生成のデモ
        Console.WriteLine();
        Console.WriteLine("LLM Prompt Generation Demo:");
        
        var assetManager = new SemanticTextAssetManager();
        var prompt = assetManager.GenerateLlmPrompt(
            "Greeting", 
            "おはようございます", 
            "polite"
        );
        
        Console.WriteLine("Generated prompt for LLM:");
        Console.WriteLine("---");
        Console.WriteLine(prompt);
        Console.WriteLine("---");
        
        // ゲーム開始
        Console.WriteLine();
        Console.WriteLine("Starting game...");
        gameEngine.StartGame();
        
        Console.WriteLine($"Current phase: {gameState.CurrentPhase}");
        Console.WriteLine($"Current date: {gameState.CurrentDate:yyyy-MM-dd}");
        
        // コマンド実行テスト
        Console.WriteLine();
        Console.WriteLine("Executing test command...");
        
        var command = new Command(
            CommandType.Talk,
            executorCharacterId: 1,
            targetCharacterId: null,
            parameters: new Dictionary<string, object> { { "topic", "greeting" } }
        );
        
        var result = gameEngine.ExecuteCommand(command);
        Console.WriteLine($"Command result: {result.Message}");
        
        Console.WriteLine();
        Console.WriteLine("Demo completed successfully!");
        Console.WriteLine();
        Console.WriteLine("Usage:");
        Console.WriteLine("  dotnet run -- <csv_directory>");
        Console.WriteLine();
        Console.WriteLine("Example:");
        Console.WriteLine("  dotnet run -- ../CSV");
    }
}
