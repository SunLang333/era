namespace eratohoK.GameEngine;

using eratohoK.Core;

/// <summary>
/// ゲーム状態マネージャー
/// ゲームの全体状態を管理する
/// </summary>
public class GameStateManager
{
    private readonly List<Character> _characters = new();
    private readonly List<Country> _countries = new();
    private readonly List<City> _cities = new();
    
    // ゲームフェーズ
    public GamePhase CurrentPhase { get; set; } = GamePhase.Title;
    
    // 現在の日付
    public DateTime CurrentDate { get; set; } = new(2024, 1, 1);
    
    // プレイヤー勢力 ID
    public int PlayerCountryId { get; set; }
    
    /// <summary>
    /// キャラクターを追加
    /// </summary>
    public void AddCharacter(Character character)
    {
        _characters.Add(character);
    }
    
    /// <summary>
    /// キャラクターを取得
    /// </summary>
    public Character? GetCharacter(int id)
    {
        return _characters.FirstOrDefault(c => c.Id == id);
    }
    
    /// <summary>
    /// すべてのキャラクターを取得
    /// </summary>
    public IReadOnlyList<Character> GetAllCharacters() => _characters.AsReadOnly();
    
    /// <summary>
    /// 勢力を追加
    /// </summary>
    public void AddCountry(Country country)
    {
        _countries.Add(country);
    }
    
    /// <summary>
    /// 勢力を取得
    /// </summary>
    public Country? GetCountry(int id)
    {
        return _countries.FirstOrDefault(c => c.Id == id);
    }
    
    /// <summary>
    /// 都市を追加
    /// </summary>
    public void AddCity(City city)
    {
        _cities.Add(city);
    }
    
    /// <summary>
    /// 都市を取得
    /// </summary>
    public City? GetCity(int id)
    {
        return _cities.FirstOrDefault(c => c.Id == id);
    }
    
    /// <summary>
    /// ターン進行
    /// </summary>
    public void AdvanceTurn()
    {
        CurrentDate = CurrentDate.AddDays(1);
        
        // 全キャラクターの行動済みフラグをリセット
        foreach (var character in _characters)
        {
            character.HasActed = false;
        }
    }
    
    /// <summary>
    /// すべての勢力を取得
    /// </summary>
    public IReadOnlyList<Country> GetAllCountries() => _countries.AsReadOnly();

    /// <summary>
    /// すべての都市を取得
    /// </summary>
    public IReadOnlyList<City> GetAllCities() => _cities.AsReadOnly();

    /// <summary>
    /// 指定した勢力に所属するキャラクターを取得
    /// </summary>
    public List<Character> GetCharactersByCountry(int countryId)
    {
        return _characters.Where(c => c.CountryId == countryId).ToList();
    }
    
    /// <summary>
    /// 指定した都市に駐留するキャラクターを取得
    /// </summary>
    public List<Character> GetCharactersByCity(int cityId)
    {
        return _characters.Where(c => c.CityId == cityId).ToList();
    }

    // ─── Save/Load helpers ──────────────────────────────────────────

    /// <summary>現在のゲーム状態から SaveData を生成する</summary>
    public SaveData CreateSaveData(int day, int playerCharId, List<int> targetIds,
        int gold, List<int> itemIds)
        => new()
        {
            Day                  = day,
            CurrentDate          = CurrentDate,
            PlayerCharacterId    = playerCharId,
            TargetCharacterIds   = targetIds,
            PlayerCountryId      = PlayerCountryId,
            PlayerGold           = gold,
            OwnedItemIds         = itemIds,
            Characters           = _characters.Select(CharSave.From).ToList(),
            Countries            = _countries.Select(CountrySave.From).ToList(),
            Cities               = _cities.Select(CitySave.From).ToList(),
            SavedAt              = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
        };

    /// <summary>SaveData からゲーム状態を復元する</summary>
    public void RestoreFromSaveData(SaveData data)
    {
        _characters.Clear();
        _countries.Clear();
        _cities.Clear();
        _characters.AddRange(data.Characters.Select(d => d.ToCharacter()));
        _countries.AddRange(data.Countries.Select(d => d.ToCountry()));
        _cities.AddRange(data.Cities.Select(d => d.ToCity()));
        CurrentDate     = data.CurrentDate;
        PlayerCountryId = data.PlayerCountryId;
    }
}

/// <summary>
/// ゲームフェーズ
/// </summary>
public enum GamePhase
{
    Title,          // タイトル画面
    NewGame,        // ニューゲーム設定
    BasePhase,      // 拠点フェイズ
    StrategyPhase,  // 戦略フェイズ
    Battle,         // 戦闘
    Ending,         // エンディング
    GameOver        // ゲームオーバー
}

/// <summary>
/// ゲームエンジン
/// </summary>
public class GameEngine
{
    private readonly GameStateManager _gameState;
    
    public GameEngine(GameStateManager gameState)
    {
        _gameState = gameState;
    }
    
    /// <summary>
    /// ゲームを開始
    /// </summary>
    public void StartGame()
    {
        _gameState.CurrentPhase = GamePhase.BasePhase;
    }
    
    /// <summary>
    /// ターンを実行
    /// </summary>
    public void ExecuteTurn()
    {
        _gameState.AdvanceTurn();
    }
    
    /// <summary>
    /// コマンドを実行
    /// </summary>
    public CommandResult ExecuteCommand(Command command)
    {
        // TODO: 実際のコマンド実行ロジック
        return new CommandResult(true, "コマンド実行完了");
    }
}

/// <summary>
/// コマンド
/// </summary>
public record Command(
    CommandType Type,
    int ExecutorCharacterId,
    int? TargetCharacterId = null,
    IDictionary<string, object>? Parameters = null
);

/// <summary>
/// コマンドの種類
/// </summary>
public enum CommandType
{
    Talk,           // 会話
    Train,          // 調教
    Move,           // 移動
    Rest,           // 休息
    Work,           // 作業
    Battle,         // 戦闘
    Event           // イベント
}

/// <summary>
/// コマンド実行結果
/// </summary>
public record CommandResult(
    bool Success,
    string Message,
    List<SemanticTextOutput>? Outputs = null
);

/// <summary>
/// セマンティックテキスト出力
/// LLM 潤色後のテキストを保持
/// </summary>
public record SemanticTextOutput(
    string Category,
    string Text,
    int SpeakerId = 0
);
