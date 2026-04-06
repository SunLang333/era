namespace eratohoK.Core;

/// <summary>
/// ゲーム内の基本リソースを表すインターフェース
/// リソースの解離と LLM による潤色を容易にするための基本単位
/// </summary>
public interface IGameResource
{
    /// <summary>
    /// リソースの一意な ID
    /// </summary>
    int Id { get; }
    
    /// <summary>
    /// リソースの名前 (表示用)
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// リソースの説明 (詳細説明)
    /// </summary>
    string? Description { get; }
}

/// <summary>
/// セマンティックなテキストリソース
/// LLM による潤色の対象となる基本単位
/// </summary>
public interface ISemanticText : IGameResource
{
    /// <summary>
    /// 基本意味 (コアセマンティクス)
    /// 例：「挨拶」「感謝」「謝罪」など
    /// </summary>
    string SemanticCategory { get; }
    
    /// <summary>
    /// コンテキスト情報
    /// 例：朝/昼/夜、初対面/既知、好感度レベルなど
    /// </summary>
    IDictionary<string, object?> Context { get; }
    
    /// <summary>
    /// テキストのバリエーション (LLM 生成用)
    /// </summary>
    IEnumerable<string> Variations { get; }
}

/// <summary>
/// ダイアログリソース
/// キャラクターの発話内容を表す
/// </summary>
public interface IDialogue : ISemanticText
{
    /// <summary>
    /// 話者キャラクター ID
    /// </summary>
    int SpeakerId { get; }
    
    /// <summary>
    /// 対象キャラクター ID (0 の場合は不特定)
    /// </summary>
    int TargetId { get; }
    
    /// <summary>
    /// 感情状態
    /// </summary>
    EmotionalState Emotion { get; }
    
    /// <summary>
    /// 音声ファイルパス (オプション)
    /// </summary>
    string? VoicePath { get; }
}

/// <summary>
/// 感情状態
/// </summary>
public record EmotionalState(
    int Joy = 0,      // 愉悦
    int Anger = 0,    // 怒り
    int Sorrow = 0,   // 哀しみ
    int Fear = 0,     // 恐怖
    int Desire = 0,   // 欲望
    int Shame = 0     // 恥じらい
);
