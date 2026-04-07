namespace eratohoK.Data;

using eratohoK.Core;
using System.Text;

/// <summary>
/// CSV データリーダー
/// eratohoK 形式の CSV ファイルを読み込む
/// </summary>
public class CsvDataReader : IDisposable
{
    private readonly string _csvDirectory;

    public CsvDataReader(string csvDirectory)
    {
        _csvDirectory = csvDirectory;
    }

    // ────────────────── Simple definition CSVs ──────────────────

    private List<(int Id, string Name, string Comment)> ReadDefinitionCsv(string fileName)
    {
        var filePath = Path.Combine(_csvDirectory, $"{fileName}.csv");
        if (!File.Exists(filePath)) return new();

        var results = new List<(int, string, string)>();
        using var reader = new StreamReader(filePath, detectEncodingFromByteOrderMarks: true);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            line = line.Trim();
            if (string.IsNullOrEmpty(line) || line.StartsWith(';')) continue;
            var parts = line.Split(',');
            if (parts.Length < 2) continue;
            if (!int.TryParse(parts[0].Trim(), out var id)) continue;
            var name = parts[1].Trim();
            var comment = parts.Length > 2 ? parts[2].Trim() : "";
            results.Add((id, name, comment));
        }
        return results;
    }

    public List<TrainDefinition> ReadTrainDefinitions()
        => ReadDefinitionCsv("Train")
            .Select(x => new TrainDefinition(x.Id, x.Name, TrainDefinition.InferActionType(x.Id)))
            .ToList();

    /// <summary>アイテム CSV からショップ商品を読み込む</summary>
    public List<ShopItem> ReadShopItems()
    {
        var raw = ReadDefinitionCsv("Item");
        var result = new List<ShopItem>();
        foreach (var (id, name, comment) in raw)
        {
            // Item.csv の 3 列目が価格（コメント列と兼用）
            int price = 0;
            if (!string.IsNullOrEmpty(comment))
                int.TryParse(comment.TrimStart(';').Trim().Split(';')[0].Trim(), out price);
            result.Add(new ShopItem(id, name, price));
        }
        return result;
    }

    public List<TalentDefinition> ReadTalentDefinitions()
        => ReadDefinitionCsv("Talent").Select(x => new TalentDefinition(x.Id, x.Name, x.Comment)).ToList();

    public List<AblDefinition> ReadAblDefinitions()
        => ReadDefinitionCsv("Abl").Select(x => new AblDefinition(x.Id, x.Name)).ToList();

    public List<BaseDefinition> ReadBaseDefinitions()
        => ReadDefinitionCsv("Base").Select(x => new BaseDefinition(x.Id, x.Name)).ToList();

    // ────────────────── Character CSVs ──────────────────

    /// <summary>Chara/ サブディレクトリからすべてのキャラクターを読み込む</summary>
    public List<Character> LoadAllCharacters()
    {
        var charaDir = Path.Combine(_csvDirectory, "Chara");
        if (!Directory.Exists(charaDir)) return new();

        var characters = new List<Character>();
        foreach (var file in Directory.GetFiles(charaDir, "*.csv").OrderBy(f => f))
        {
            var ch = ParseCharacterFile(file);
            if (ch != null) characters.Add(ch);
        }
        return characters;
    }

    private Character? ParseCharacterFile(string filePath)
    {
        var data = new Dictionary<string, string>(StringComparer.Ordinal);
        var cstrData = new Dictionary<int, string>();
        var kisoData = new Dictionary<string, int>(StringComparer.Ordinal);
        var soshitsuData = new Dictionary<string, int>(StringComparer.Ordinal);
        var nouryokuData = new Dictionary<string, int>(StringComparer.Ordinal);

        using var reader = new StreamReader(filePath, detectEncodingFromByteOrderMarks: true);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            line = line.Trim();
            if (string.IsNullOrEmpty(line) || line.StartsWith(';')) continue;
            var parts = line.Split(',');
            if (parts.Length < 2) continue;

            var key = parts[0].Trim();
            switch (key)
            {
                case "番号":
                case "名前":
                case "呼び名":
                    data[key] = parts[1].Trim();
                    break;
                case "CSTR":
                    if (parts.Length >= 3 && int.TryParse(parts[1].Trim(), out var cstrIdx))
                        cstrData[cstrIdx] = parts[2].Trim();
                    break;
                case "基礎":
                    if (parts.Length >= 3 && int.TryParse(parts[2].Trim(), out var kisoVal))
                        kisoData[parts[1].Trim()] = kisoVal;
                    break;
                case "素質":
                    if (parts.Length >= 3 && int.TryParse(parts[2].Trim(), out var sosVal))
                        soshitsuData[parts[1].Trim()] = sosVal;
                    break;
                case "能力":
                    if (parts.Length >= 3 && int.TryParse(parts[2].Trim(), out var nouVal))
                        nouryokuData[parts[1].Trim()] = nouVal;
                    break;
            }
        }

        if (!data.TryGetValue("番号", out var idStr) || !int.TryParse(idStr, out var id))
            return null;

        data.TryGetValue("名前", out var name);
        data.TryGetValue("呼び名", out var nickname);

        var baseStatus = new BaseStatus(
            Physical: kisoData.GetValueOrDefault("体力", 100),
            Mental: kisoData.GetValueOrDefault("気力", 100),
            Resistance: soshitsuData.GetValueOrDefault("反抗心", 0),
            Obedience: soshitsuData.GetValueOrDefault("従順", 0)
        );

        var ability = new Ability(
            Fight: nouryokuData.GetValueOrDefault("武闘", 0),
            Command: nouryokuData.GetValueOrDefault("防衛", 0),
            Intelligence: nouryokuData.GetValueOrDefault("知略", 0),
            Politics: nouryokuData.GetValueOrDefault("政治", 0),
            Magic: nouryokuData.GetValueOrDefault("魔法", 0),
            Talk: nouryokuData.GetValueOrDefault("話術", 0),
            Heal: nouryokuData.GetValueOrDefault("治療", 0)
        );

        var genderVal = soshitsuData.GetValueOrDefault("性別", 1);
        var gender = (genderVal >= 0 && genderVal <= 5) ? (Gender)genderVal : Gender.Female;

        static bool GetBoolValue(Dictionary<string, int> dictionary, string key, int def = 0)
            => dictionary.GetValueOrDefault(key, def) != 0;

        var talent = new Talent(
            Gender: gender,
            IsVirgin: GetBoolValue(soshitsuData, "処女", 1),
            IsMaleVirgin: GetBoolValue(soshitsuData, "童貞", 1),
            IsKissInexperienced: GetBoolValue(soshitsuData, "キス未経験", 1),
            IsAnalVirgin: GetBoolValue(soshitsuData, "アナル処女", 1),
            IsCowardly: GetBoolValue(soshitsuData, "臆病"),
            IsRebellious: GetBoolValue(soshitsuData, "反抗的"),
            IsStoic: GetBoolValue(soshitsuData, "気丈"),
            IsHonest: GetBoolValue(soshitsuData, "素直"),
            IsQuiet: GetBoolValue(soshitsuData, "大人しい"),
            IsProud: GetBoolValue(soshitsuData, "プライド高い"),
            IsArrogant: GetBoolValue(soshitsuData, "生意気"),
            IsLowPride: GetBoolValue(soshitsuData, "プライド低い"),
            IsTsundere: GetBoolValue(soshitsuData, "ツンデレ"),
            IsSelfControlled: GetBoolValue(soshitsuData, "自制心"),
            IsIndifferent: GetBoolValue(soshitsuData, "無関心"),
            IsEmotionless: GetBoolValue(soshitsuData, "感情乏しい"),
            IsCurious: GetBoolValue(soshitsuData, "好奇心"),
            IsConservative: GetBoolValue(soshitsuData, "保守的"),
            IsOptimistic: GetBoolValue(soshitsuData, "楽観的"),
            IsPessimistic: GetBoolValue(soshitsuData, "悲観的"),
            IsNotCrossingLine: GetBoolValue(soshitsuData, "一線越えない"),
            IsAttentionSeeker: GetBoolValue(soshitsuData, "目立ちたがり"),
            HasChastityConcept: GetBoolValue(soshitsuData, "貞操観念"),
            IsChastityIndifferent: GetBoolValue(soshitsuData, "貞操無頓着"),
            IsSuppressed: GetBoolValue(soshitsuData, "抑圧"),
            IsLiberated: GetBoolValue(soshitsuData, "解放"),
            IsSolitary: GetBoolValue(soshitsuData, "孤高"),
            IsShy: GetBoolValue(soshitsuData, "恥じらい"),
            IsShameless: GetBoolValue(soshitsuData, "恥薄い"),
            IsSlacker: GetBoolValue(soshitsuData, "サボり魔"),
            IsWeakToPain: GetBoolValue(soshitsuData, "痛みに弱い"),
            IsStrongToPain: GetBoolValue(soshitsuData, "痛みに強い"),
            IsEasilyWet: GetBoolValue(soshitsuData, "濡れやすい"),
            IsHardlyWet: GetBoolValue(soshitsuData, "濡れにくい"),
            LearnsFast: GetBoolValue(soshitsuData, "習得早い"),
            LearnsSlow: GetBoolValue(soshitsuData, "習得遅い"),
            IsSkilledWithTongue: GetBoolValue(soshitsuData, "舌使い"),
            HasUrinationQuirk: GetBoolValue(soshitsuData, "おもらし癖"),
            MasturbatesEasily: GetBoolValue(soshitsuData, "自慰しやすい"),
            IsInsensitiveToOdor: GetBoolValue(soshitsuData, "汚臭鈍感"),
            IsSensitiveToOdor: GetBoolValue(soshitsuData, "汚臭敏感"),
            IsDevoted: GetBoolValue(soshitsuData, "献身的"),
            IgnoresDirt: GetBoolValue(soshitsuData, "汚れ無視")
        );

        cstrData.TryGetValue(0, out var familyName);
        cstrData.TryGetValue(1, out var firstName);
        var desc = string.Join(" ", new[] { familyName, firstName }.Where(s => !string.IsNullOrEmpty(s)));

        return new Character
        {
            Id = id,
            No = id,
            Name = name ?? string.Empty,
            Nickname = nickname ?? string.Empty,
            Gender = gender,
            BaseStatus = baseStatus,
            Ability = ability,
            Talent = talent,
            Description = string.IsNullOrEmpty(desc) ? null : desc
        };
    }

    public void Dispose() { }
}

// ────────────────── Definition records ──────────────────

/// <summary>素質定義</summary>
public record TalentDefinition(int Id, string Name, string Comment);

/// <summary>調教定義（ActionType はコマンド ID から推定）</summary>
public record TrainDefinition(int Id, string Name,
    eratohoK.Core.TrainingActionType ActionType = eratohoK.Core.TrainingActionType.Caress)
{
    /// <summary>Train CSV の ID からアクションタイプを推定する</summary>
    public static eratohoK.Core.TrainingActionType InferActionType(int id) => id switch
    {
        // 愛撫系（Caress）
        0 or 1 or 5 or 12 or 13 or 14 or 15 or 17 or 18 or 25 or 26
            => eratohoK.Core.TrainingActionType.Caress,
        // 口技系（Oral）
        2 or 8 or 9 or 10 or 11 or 19 or 24 or 90
            => eratohoK.Core.TrainingActionType.Oral,
        // 挿入系（Vaginal）
        3 or 6 or 21 or 23 or >= 30 and <= 39 or 52 or 55 or 57 or 160
            => eratohoK.Core.TrainingActionType.Vaginal,
        // アナル系（Anal）
        4 or 7 or >= 40 and <= 49 or 53 or 56 or 58 or 161
            => eratohoK.Core.TrainingActionType.Anal,
        // 器具系（Toy）
        16 or 22 or >= 60 and <= 68
            => eratohoK.Core.TrainingActionType.Toy,
        // 日常系（Daily）
        20 or 50 or 51 or >= 70 and <= 79
            => eratohoK.Core.TrainingActionType.Daily,
        // 制裁系（Punishment）
        >= 80 and <= 99
            => eratohoK.Core.TrainingActionType.Punishment,
        _ => eratohoK.Core.TrainingActionType.Caress
    };
}

/// <summary>能力定義</summary>
public record AblDefinition(int Id, string Name);

/// <summary>基礎能力定義</summary>
public record BaseDefinition(int Id, string Name);

