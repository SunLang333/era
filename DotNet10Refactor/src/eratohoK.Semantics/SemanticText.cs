namespace eratohoK.Semantics;

using eratohoK.Core;

/// <summary>
/// セマンティックカテゴリ
/// 会話や描写を基本意味に分解するための分類
/// </summary>
public enum SemanticCategoryType
{
    // 基本挨拶
    Greeting,           // 挨拶
    Farewell,          // 別れ
    Thanks,            // 感謝
    Apology,           // 謝罪
    
    // 感情表現
    Joy,               // 喜び
    Anger,             // 怒り
    Sorrow,            // 悲しみ
    Fear,              // 恐怖
    Surprise,          // 驚き
    Disgust,           // 嫌悪
    
    // 状態描写
    Morning,           // 朝
    Noon,              // 昼
    Evening,           // 夕方
    Night,             // 夜
    Sleepy,            // 眠い
    Hungry,            // お腹空いた
    
    // 関係性
    FirstMeeting,      // 初対面
    Familiar,          // 馴染み
    Intimate,          // 親密
    Hostile,           // 敵対
    
    // 調教関連
    TrainingStart,     // 調教開始
    TrainingEnd,       // 調教終了
    Pleasure,          // 快感
    Pain,              // 痛み
    Resistance,        // 抵抗
    Submission,        // 服従
    Corruption,        // 堕落
    
    // 特殊状況
    Pregnant,          // 妊娠
    Injured,           // 受傷
    Exhausted,         // 疲労
    Drunk,             // 酔い
    
    // コマンド関連
    CommandAccept,     // コマンド受諾
    CommandRefuse,     // コマンド拒否
    CommandRequest     // コマンド要求
}

/// <summary>
/// セマンティックテキストの基本実装
/// </summary>
public class SemanticText : ISemanticText
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public string SemanticCategory { get; set; } = string.Empty;
    
    public IDictionary<string, object?> Context { get; set; } = new Dictionary<string, object?>();
    
    public IEnumerable<string> Variations { get; set; } = Enumerable.Empty<string>();
    
    /// <summary>
    /// コンテキスト条件を満たしているか確認
    /// </summary>
    public bool MatchesContext(IDictionary<string, object?> currentContext)
    {
        foreach (var kvp in Context)
        {
            if (!currentContext.TryGetValue(kvp.Key, out var currentValue))
            {
                return false;
            }
            
            if (kvp.Value != null && !kvp.Value.Equals(currentValue))
            {
                return false;
            }
        }
        return true;
    }
}

/// <summary>
/// ダイアログの実装
/// </summary>
public class Dialogue : SemanticText, IDialogue
{
    public int SpeakerId { get; set; }
    public int TargetId { get; set; }
    public EmotionalState Emotion { get; set; } = new();
    public string? VoicePath { get; set; }
}

/// <summary>
/// ナレーション/描写テキスト
/// </summary>
public class Narration : SemanticText
{
    /// <summary>
    /// 描写の強度レベル (0-100)
    /// </summary>
    public int Intensity { get; set; } = 50;
    
    /// <summary>
    /// 対象となるキャラクター ID リスト
    /// </summary>
    public List<int> TargetCharacterIds { get; set; } = new();
}

/// <summary>
/// セマンティックテキストアセットマネージャー
/// LLM 潤色用のテキスト資産を管理
/// </summary>
public class SemanticTextAssetManager
{
    private readonly Dictionary<string, List<SemanticText>> _assets = new();
    
    /// <summary>
    /// アセットを追加
    /// </summary>
    public void AddAsset(SemanticText text)
    {
        if (!_assets.ContainsKey(text.SemanticCategory))
        {
            _assets[text.SemanticCategory] = new List<SemanticText>();
        }
        _assets[text.SemanticCategory].Add(text);
    }
    
    /// <summary>
    /// カテゴリとコンテキストに一致するテキストを取得
    /// </summary>
    public IEnumerable<SemanticText> GetTexts(string category, IDictionary<string, object?> context)
    {
        if (!_assets.TryGetValue(category, out var texts))
        {
            return Enumerable.Empty<SemanticText>();
        }
        
        return texts.Where(t => t.MatchesContext(context));
    }
    
    /// <summary>
    /// ランダムにテキストを選択
    /// </summary>
    public SemanticText? SelectRandom(string category, IDictionary<string, object?> context)
    {
        var candidates = GetTexts(category, context).ToList();
        if (candidates.Count == 0)
        {
            return null;
        }
        
        var random = new Random();
        return candidates[random.Next(candidates.Count)];
    }
    
    /// <summary>
    /// LLM 潤色用のプロンプト生成
    /// </summary>
    public string GenerateLlmPrompt(string category, string baseText, string style = "default")
    {
        return $"""
            あなたはゲームのシナリオライターです。
            以下の基本意味カテゴリに基づいて、テキストを潤色してください。
            
            カテゴリ：{category}
            基本テキスト：{baseText}
            スタイル：{style}
            
            要件:
            - 元の意味を保つこと
            - キャラクターの性格に合うこと
            - 自然な日本語であること
            - バリエーションを 3 つ生成すること
            
            出力形式:
            1. [バリエーション 1]
            2. [バリエーション 2]
            3. [バリエーション 3]
            """;
    }
}
