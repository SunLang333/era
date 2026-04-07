namespace eratohoK.Semantics;

using eratohoK.Core;
using System.Text;

/// <summary>
/// CSV からセマンティックテキストを構築するファクトリー
/// 既存の CSV データを解離して基本意味単位に分解
/// </summary>
public class SemanticTextFactory
{
    private readonly string? _contentRoot;

    public SemanticTextFactory(string? contentRoot = null)
    {
        _contentRoot = contentRoot;
    }
    
    /// <summary>
    /// 口上 CSV からセマンティックテキストを生成
    /// </summary>
    public List<SemanticText> BuildFromKoujouCsv(string characterId)
    {
        var compiler = new KoujouSemanticCompiler(_contentRoot);
        var compilation = compiler.CompileCharacter(characterId);
        if (compilation == null)
        {
            return [];
        }

        var texts = new List<SemanticText>();
        var nextId = 1;

        foreach (var emission in compiler.EnumerateTextEmissions(compilation))
        {
            var category = InferSemanticCategory(
                emission.Text,
                emission.ProcedureName,
                emission.FilePath,
                emission.ConditionTrail);

            var context = ExtractContextFromText(emission.Text);
            context["SourceKind"] = "KoujouErb";
            context["SourceProcedure"] = emission.ProcedureName;
            context["SourceCommand"] = emission.Command;
            context["SourceRelativePath"] = emission.RelativeFilePath;
            context["ConditionDepth"] = emission.ConditionTrail.Count;
            context["IsDialogue"] = emission.IsDialogue;
            if (emission.ConditionTrail.Count > 0)
            {
                context["ConditionTrail"] = emission.ConditionTrail.ToArray();
            }

            if (int.TryParse(emission.CharacterId, out var parsedCharacterId))
            {
                context["CharacterId"] = parsedCharacterId;
            }
            context["CharacterName"] = emission.CharacterName;

            var rawConditionSnippet = emission.ConditionTrail.Count == 0
                ? null
                : string.Join(Environment.NewLine, emission.ConditionTrail);

            SemanticText asset = emission.IsDialogue
                ? new Dialogue
                {
                    SpeakerId = int.TryParse(emission.CharacterId, out var speakerId) ? speakerId : 0,
                    TargetId = 0,
                    Emotion = InferEmotionalStateFromCategory(category)
                }
                : new Narration
                {
                    Intensity = InferNarrationIntensity(emission.Text),
                    TargetCharacterIds = int.TryParse(emission.CharacterId, out var targetId) ? [targetId] : []
                };

            asset.Id = nextId++;
            asset.Name = BuildAssetName(emission.ProcedureName, emission.Text);
            asset.Description = emission.Text;
            asset.SemanticCategory = category;
            asset.Context = context;
            asset.Variations = [emission.Text];
            asset.SourceFilePath = emission.FilePath;
            asset.SourceLineStart = emission.SourceLineStart;
            asset.SourceLineEnd = emission.SourceLineEnd;
            asset.SourceSymbol = emission.ProcedureSignature ?? emission.ProcedureName;
            asset.NormalizedConditions = emission.NormalizedConditionTrail;
            asset.RawConditionSnippet = rawConditionSnippet;
            asset.CharacterId = int.TryParse(emission.CharacterId, out var finalCharacterId) ? finalCharacterId : null;
            asset.CharacterName = emission.CharacterName;
            asset.ExtractionStage = rawConditionSnippet == null
                ? SemanticExtractionStage.Reviewed
                : SemanticExtractionStage.ConditionAnnotated;
            asset.ExtractionConfidence = CalculateExtractionConfidence(emission.Text, rawConditionSnippet, asset);

            texts.Add(asset);
        }

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

    private void ParseKoujouFile(
        string filePath,
        (int? CharacterId, string CharacterName) metadata,
        List<SemanticText> texts,
        ref int nextId)
    {
        var lines = File.ReadAllLines(filePath);
        var currentSymbol = Path.GetFileName(filePath);
        var conditionBuffer = new List<string>();

        for (int i = 0; i < lines.Length; i++)
        {
            var rawLine = lines[i];
            var trimmed = rawLine.Trim();

            if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith(';'))
            {
                continue;
            }

            if (trimmed.StartsWith('@'))
            {
                currentSymbol = trimmed;
                conditionBuffer.Clear();
                continue;
            }

            if (IsContextResetLine(trimmed))
            {
                conditionBuffer.Clear();
                continue;
            }

            if (IsConditionLikeLine(trimmed))
            {
                conditionBuffer.Add(trimmed);
                if (conditionBuffer.Count > 8)
                {
                    conditionBuffer.RemoveAt(0);
                }
                continue;
            }

            if (!TryExtractPrintedText(trimmed, out var text))
            {
                continue;
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                continue;
            }

            var semanticCategory = InferSemanticCategory(text);
            var context = ExtractContextFromText(text);
            context["SourceKind"] = "KoujouErb";
            context["SourceSymbol"] = currentSymbol;
            if (metadata.CharacterId.HasValue)
            {
                context["CharacterId"] = metadata.CharacterId.Value;
            }
            context["CharacterName"] = metadata.CharacterName;

            var rawConditionSnippet = conditionBuffer.Count == 0
                ? null
                : string.Join(Environment.NewLine, conditionBuffer);

            SemanticText asset = LooksLikeDialogue(text)
                ? new Dialogue
                {
                    SpeakerId = metadata.CharacterId ?? 0,
                    TargetId = 0,
                    Emotion = InferEmotionalStateFromText(text)
                }
                : new Narration
                {
                    Intensity = InferNarrationIntensity(text),
                    TargetCharacterIds = metadata.CharacterId.HasValue ? [metadata.CharacterId.Value] : []
                };

            asset.Id = nextId++;
            asset.Name = BuildAssetName(currentSymbol, text);
            asset.Description = text;
            asset.SemanticCategory = semanticCategory;
            asset.Context = context;
            asset.Variations = [text];
            asset.SourceFilePath = filePath;
            asset.SourceLineStart = i + 1;
            asset.SourceLineEnd = i + 1;
            asset.SourceSymbol = currentSymbol;
            asset.RawConditionSnippet = rawConditionSnippet;
            asset.CharacterId = metadata.CharacterId;
            asset.CharacterName = metadata.CharacterName;
            asset.ExtractionStage = rawConditionSnippet == null
                ? SemanticExtractionStage.Heuristic
                : SemanticExtractionStage.ConditionAnnotated;
            asset.ExtractionConfidence = CalculateExtractionConfidence(text, rawConditionSnippet, asset);

            texts.Add(asset);
        }
    }

    private string? ResolveKoujouRoot()
    {
        var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var root in EnumerateCandidateRoots())
        {
            if (string.IsNullOrWhiteSpace(root))
            {
                continue;
            }

            var fullRoot = Path.GetFullPath(root);
            if (!visited.Add(fullRoot))
            {
                continue;
            }

            if (Directory.Exists(fullRoot) &&
                string.Equals(Path.GetFileName(fullRoot), "口上", StringComparison.OrdinalIgnoreCase))
            {
                return fullRoot;
            }

            var koujouUnderErb = Path.Combine(fullRoot, "ERB", "口上");
            if (Directory.Exists(koujouUnderErb))
            {
                return koujouUnderErb;
            }

            var directKoujou = Path.Combine(fullRoot, "口上");
            if (Directory.Exists(directKoujou))
            {
                return directKoujou;
            }
        }

        return null;
    }

    private IEnumerable<string> EnumerateCandidateRoots()
    {
        if (!string.IsNullOrWhiteSpace(_contentRoot))
        {
            yield return _contentRoot;
        }

        yield return Directory.GetCurrentDirectory();
        yield return AppContext.BaseDirectory;

        foreach (var seed in new[] { _contentRoot, Directory.GetCurrentDirectory(), AppContext.BaseDirectory }
                     .Where(static value => !string.IsNullOrWhiteSpace(value))
                     .Distinct(StringComparer.OrdinalIgnoreCase)
                     .Cast<string>())
        {
            var current = new DirectoryInfo(Path.GetFullPath(seed));
            while (current != null)
            {
                yield return current.FullName;
                current = current.Parent;
            }
        }
    }

    private static string? FindCharacterDirectory(string koujouRoot, string characterId)
    {
        var directories = Directory.EnumerateDirectories(koujouRoot).ToList();
        if (TryParseCharacterNumber(characterId, out var requestedId))
        {
            return directories.FirstOrDefault(dir =>
                TryParseCharacterNumber(Path.GetFileName(dir), out var currentId) && currentId == requestedId);
        }

        return directories.FirstOrDefault(dir =>
            Path.GetFileName(dir).Contains(characterId, StringComparison.OrdinalIgnoreCase));
    }

    private static (int? CharacterId, string CharacterName) ParseCharacterMetadata(string? directoryName)
    {
        directoryName ??= string.Empty;
        int? characterId = null;
        if (TryParseCharacterNumber(directoryName, out var id))
        {
            characterId = id;
        }

        var nameBuilder = new StringBuilder(directoryName.Length);
        foreach (var ch in directoryName)
        {
            if (!char.IsDigit(ch))
            {
                nameBuilder.Append(ch);
            }
        }

        var name = nameBuilder.ToString().Replace("口上", string.Empty, StringComparison.Ordinal).Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            name = directoryName.Trim();
        }

        return (characterId, name);
    }

    private static bool IsSupportedKoujouFile(string path)
    {
        var extension = Path.GetExtension(path);
        return extension.Equals(".ERB", StringComparison.OrdinalIgnoreCase)
               || extension.Equals(".ERH", StringComparison.OrdinalIgnoreCase);
    }

    private static bool TryParseCharacterNumber(string input, out int characterId)
    {
        var digits = new string((input ?? string.Empty).Where(char.IsDigit).ToArray());
        return int.TryParse(digits, out characterId);
    }

    private static bool IsContextResetLine(string line)
        => line.Equals("ENDIF", StringComparison.OrdinalIgnoreCase)
           || line.Equals("ENDSELECT", StringComparison.OrdinalIgnoreCase)
           || line.Equals("ENDDATA", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("RETURN", StringComparison.OrdinalIgnoreCase);

    private static bool IsConditionLikeLine(string line)
        => line.StartsWith("IF ", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("ELSEIF", StringComparison.OrdinalIgnoreCase)
           || line.Equals("ELSE", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("SIF ", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("SELECTCASE", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("CASE", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("TRY", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("CATCH", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("$", StringComparison.OrdinalIgnoreCase)
           || line.StartsWith("GOTO", StringComparison.OrdinalIgnoreCase);

    private static bool TryExtractPrintedText(string line, out string text)
    {
        text = string.Empty;

        var commands = new[] { "PRINTFORMW", "PRINTFORML", "PRINTFORM" };
        foreach (var command in commands)
        {
            if (!line.StartsWith(command, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            text = line[command.Length..].Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return true;
        }

        return false;
    }

    private static bool LooksLikeDialogue(string text)
    {
        var trimmed = text.TrimStart();
        return trimmed.StartsWith('「')
               || trimmed.StartsWith('『')
               || trimmed.StartsWith('“')
               || (trimmed.StartsWith('"') && trimmed.EndsWith('"'));
    }

    private static string BuildAssetName(string currentSymbol, string text)
    {
        var prefix = string.IsNullOrWhiteSpace(currentSymbol)
            ? "Koujou"
            : currentSymbol.TrimStart('@');
        var snippet = text.Length > 12 ? text[..12] + "…" : text;
        return $"{prefix}: {snippet}";
    }

    private static EmotionalState InferEmotionalStateFromText(string text)
    {
        var category = InferSemanticCategory(text);
        return InferEmotionalStateFromCategory(category);
    }

    private static EmotionalState InferEmotionalStateFromCategory(string category)
    {
        return category switch
        {
            nameof(SemanticCategoryType.Joy) => new EmotionalState(Joy: 60),
            nameof(SemanticCategoryType.Anger) => new EmotionalState(Anger: 60),
            nameof(SemanticCategoryType.Sorrow) => new EmotionalState(Sorrow: 60),
            nameof(SemanticCategoryType.Fear) => new EmotionalState(Fear: 60),
            nameof(SemanticCategoryType.Pleasure) => new EmotionalState(Joy: 35, Desire: 55),
            nameof(SemanticCategoryType.Pain) => new EmotionalState(Fear: 20, Sorrow: 15),
            _ => new EmotionalState()
        };
    }

    private static int InferNarrationIntensity(string text)
    {
        var score = 40;
        if (text.Contains('！') || text.Contains('!')) score += 15;
        if (text.Contains('？') || text.Contains('?')) score += 10;
        if (text.Contains("……", StringComparison.Ordinal)) score += 5;
        if (text.Length > 40) score += 10;
        return Math.Clamp(score, 0, 100);
    }

    private static double CalculateExtractionConfidence(string text, string? rawConditionSnippet, SemanticText asset)
    {
        var confidence = asset switch
        {
            Dialogue => 0.88,
            Narration => 0.78,
            _ => 0.7
        };

        if (!string.IsNullOrWhiteSpace(rawConditionSnippet))
        {
            confidence -= 0.08;
        }

        if (text.Contains('%'))
        {
            confidence -= 0.05;
        }

        if (text.Length < 4)
        {
            confidence -= 0.08;
        }

        return Math.Clamp(confidence, 0.1, 0.99);
    }
    
    /// <summary>
    /// テキストからセマンティックカテゴリを推定
    /// </summary>
    private static string InferSemanticCategory(string text)
        => InferSemanticCategory(text, null, null, null);

    private static string InferSemanticCategory(
        string text,
        string? sourceSymbol,
        string? sourceFilePath,
        IReadOnlyList<string>? conditionTrail)
    {
        var lowerText = text.ToLower();

        if (!string.IsNullOrWhiteSpace(sourceSymbol))
        {
            var upperSymbol = sourceSymbol.ToUpperInvariant();
            if (upperSymbol.Contains("TRAIN_START", StringComparison.Ordinal)
                || upperSymbol.Contains("KOJO_TRAIN_START", StringComparison.Ordinal)
                || upperSymbol.Contains("_START_", StringComparison.Ordinal))
                return SemanticCategoryType.TrainingStart.ToString();

            if (upperSymbol.Contains("TRAIN_END", StringComparison.Ordinal)
                || upperSymbol.Contains("KOJO_TRAIN_END", StringComparison.Ordinal)
                || upperSymbol.Contains("COM_AFTER", StringComparison.Ordinal))
                return SemanticCategoryType.TrainingEnd.ToString();
        }

        if (!string.IsNullOrWhiteSpace(sourceFilePath))
        {
            if (sourceFilePath.Contains($"{Path.DirectorySeparatorChar}DAILY{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
            {
                if (lowerText.Contains("夜") || lowerText.Contains("深夜"))
                    return SemanticCategoryType.Night.ToString();
                return SemanticCategoryType.Familiar.ToString();
            }
        }

        if (conditionTrail != null && conditionTrail.Count > 0)
        {
            var flattenedConditions = string.Join(" ", conditionTrail).ToLowerInvariant();
            if (flattenedConditions.Contains("恋人") || flattenedConditions.Contains("恋慕"))
                return SemanticCategoryType.Intimate.ToString();
            if (flattenedConditions.Contains("反抗") || flattenedConditions.Contains("怒り"))
                return SemanticCategoryType.Resistance.ToString();
        }
        
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

