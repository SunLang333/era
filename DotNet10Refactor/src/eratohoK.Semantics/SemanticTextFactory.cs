namespace eratohoK.Semantics;

using eratohoK.Core;

/// <summary>
/// CSV からセマンティックテキストを構築するファクトリー
/// 既存の CSV データを解離して基本意味単位に分解
/// </summary>
public class SemanticTextFactory
{
    public SemanticTextFactory() { }
    
    /// <summary>
    /// 口上 CSV からセマンティックテキストを生成
    /// </summary>
    public List<SemanticText> BuildFromKoujouCsv(string characterId)
    {
        var texts = new List<SemanticText>();
        
        // 口上ファイルのパスを構築
        var koujouPath = Path.Combine("口上", $"{characterId}");
        
        // TODO: 実際の実装では、口上ファイルをパースして
        // セマンティックカテゴリに分類する
        
        return texts;
    }
    
    /// <summary>
    /// デイリーイベント CSV からセマンティックテキストを生成
    /// </summary>
    public List<SemanticText> BuildFromDailyEventCsv()
    {
        var texts = new List<SemanticText>();
        
        // TODO: デイリーイベントファイルをパース
        
        return texts;
    }
    
    /// <summary>
    /// 重複した会話/描写を基本意味に分解
    /// </summary>
    public List<SemanticText> DecomposeToBasicSemantics(IEnumerable<string> rawTexts)
    {
        var decomposed = new List<SemanticText>();
        var idCounter = 1;
        
        foreach (var text in rawTexts.Distinct())
        {
            // 自動でセマンティックカテゴリを推定
            var category = InferSemanticCategory(text);
            
            var semanticText = new SemanticText
            {
                Id = idCounter++,
                Name = text.Length > 20 ? text[..20] + "..." : text,
                Description = text,
                SemanticCategory = category,
                Context = ExtractContextFromText(text),
                Variations = new[] { text }
            };
            
            decomposed.Add(semanticText);
        }
        
        return decomposed;
    }
    
    /// <summary>
    /// テキストからセマンティックカテゴリを推定
    /// </summary>
    private static string InferSemanticCategory(string text)
    {
        var lowerText = text.ToLower();
        
        if (lowerText.Contains("おはよう") || lowerText.Contains("こんにちは") || lowerText.Contains("こんばんは"))
            return SemanticCategoryType.Greeting.ToString();
        
        if (lowerText.Contains("ありがとう") || lowerText.Contains("感謝"))
            return SemanticCategoryType.Thanks.ToString();
        
        if (lowerText.Contains("ごめん") || lowerText.Contains("謝罪"))
            return SemanticCategoryType.Apology.ToString();
        
        if (lowerText.Contains("嬉しい") || lowerText.Contains("楽しい") || lowerText.Contains("幸せ"))
            return SemanticCategoryType.Joy.ToString();
        
        if (lowerText.Contains("怒り") || lowerText.Contains("許さない"))
            return SemanticCategoryType.Anger.ToString();
        
        if (lowerText.Contains("悲しい") || lowerText.Contains("泣き"))
            return SemanticCategoryType.Sorrow.ToString();
        
        if (lowerText.Contains("怖い") || lowerText.Contains("恐ろしい"))
            return SemanticCategoryType.Fear.ToString();
        
        if (lowerText.Contains("朝") || lowerText.Contains("起床"))
            return SemanticCategoryType.Morning.ToString();
        
        if (lowerText.Contains("夜") || lowerText.Contains("就寝"))
            return SemanticCategoryType.Night.ToString();
        
        if (lowerText.Contains("調教") || lowerText.Contains("訓練"))
            return SemanticCategoryType.TrainingStart.ToString();
        
        if (lowerText.Contains("快感") || lowerText.Contains("気持ちいい"))
            return SemanticCategoryType.Pleasure.ToString();
        
        if (lowerText.Contains("痛い") || lowerText.Contains("苦痛"))
            return SemanticCategoryType.Pain.ToString();
        
        return "General"; // デフォルト
    }
    
    /// <summary>
    /// テキストからコンテキスト情報を抽出
    /// </summary>
    private static IDictionary<string, object?> ExtractContextFromText(string text)
    {
        var context = new Dictionary<string, object?>();
        
        // 時間帯の推定
        if (text.Contains("朝") || text.Contains("おはよう"))
            context["TimeOfDay"] = "Morning";
        else if (text.Contains("昼") || text.Contains("こんにちは"))
            context["TimeOfDay"] = "Noon";
        else if (text.Contains("夜") || text.Contains("こんばんは"))
            context["TimeOfDay"] = "Night";
        
        // 感情の推定
        if (text.Contains("嬉しい") || text.Contains("楽しい"))
            context["Emotion"] = "Joy";
        else if (text.Contains("怒り") || text.Contains("許さない"))
            context["Emotion"] = "Anger";
        else if (text.Contains("悲しい") || text.Contains("泣き"))
            context["Emotion"] = "Sorrow";
        else if (text.Contains("怖い"))
            context["Emotion"] = "Fear";
        
        return context;
    }
}
