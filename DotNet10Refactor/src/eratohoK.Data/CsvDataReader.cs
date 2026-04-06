namespace eratohoK.Data;

using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

/// <summary>
/// CSV データリーダー
/// 元の CSV フォーマットと互換性を持ちながら、
/// 型安全なデータアクセスを提供する
/// </summary>
public class CsvDataReader : IDisposable
{
    private readonly string _csvDirectory;
    private readonly Dictionary<string, List<IDictionary<string, string>>> _cache = new();
    
    public CsvDataReader(string csvDirectory)
    {
        _csvDirectory = csvDirectory;
    }
    
    /// <summary>
    /// CSV ファイルを読み込む
    /// </summary>
    /// <param name="fileName">ファイル名 (拡張子なし)</param>
    /// <returns>行ごとのディクショナリリスト</returns>
    public List<IDictionary<string, string>> ReadCsv(string fileName)
    {
        if (_cache.TryGetValue(fileName, out var cached))
        {
            return cached;
        }
        
        var filePath = Path.Combine(_csvDirectory, $"{fileName}.csv");
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"CSV file not found: {filePath}");
        }
        
        var records = new List<IDictionary<string, string>>();
        
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        
        // ヘッダーを読み取る
        var headers = new List<string>();
        while (csv.Read())
        {
            if (csv.Parser.Record == null) continue;
            
            if (headers.Count == 0)
            {
                // 最初の行はヘッダー (ID, 名前，説明...)
                for (int i = 0; i < csv.Parser.Record.Length; i++)
                {
                    headers.Add(csv.Parser.Record[i] ?? $"Column{i}");
                }
                continue;
            }
            
            var record = new Dictionary<string, string>();
            for (int i = 0; i < csv.Parser.Record.Length; i++)
            {
                var header = i < headers.Count ? headers[i] : $"Column{i}";
                record[header] = csv.Parser.Record[i] ?? string.Empty;
            }
            records.Add(record);
        }
        
        _cache[fileName] = records;
        return records;
    }
    
    /// <summary>
    /// Talent.csv を読み込んでパースする
    /// </summary>
    public List<TalentDefinition> ReadTalentDefinitions()
    {
        var records = ReadCsv("Talent");
        var definitions = new List<TalentDefinition>();
        
        foreach (var record in records)
        {
            if (!record.ContainsKey("0") || string.IsNullOrEmpty(record["0"]))
                continue;
                
            int id = int.Parse(record["0"]);
            string name = record.ContainsKey("1") ? record["1"] : string.Empty;
            string description = record.ContainsKey("2") ? record["2"] : string.Empty;
            
            definitions.Add(new TalentDefinition(id, name, description));
        }
        
        return definitions;
    }
    
    /// <summary>
    /// Train.csv を読み込んでパースする
    /// </summary>
    public List<TrainDefinition> ReadTrainDefinitions()
    {
        var records = ReadCsv("Train");
        var definitions = new List<TrainDefinition>();
        
        foreach (var record in records)
        {
            if (!record.ContainsKey("0") || string.IsNullOrEmpty(record["0"]))
                continue;
                
            int id = int.Parse(record["0"]);
            string name = record.ContainsKey("1") ? record["1"] : string.Empty;
            
            definitions.Add(new TrainDefinition(id, name));
        }
        
        return definitions;
    }
    
    /// <summary>
    /// キャラクター CSV ディレクトリを読み込む
    /// </summary>
    public List<CharacterCsvData> ReadCharacterCsvs()
    {
        var charaDir = Path.Combine(_csvDirectory, "Chara");
        if (!Directory.Exists(charaDir))
        {
            return new List<CharacterCsvData>();
        }
        
        var characters = new List<CharacterCsvData>();
        foreach (var file in Directory.GetFiles(charaDir, "*.csv"))
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            var records = ReadCsv($"Chara/{fileName}");
            
            if (records.Count > 0)
            {
                characters.Add(new CharacterCsvData(fileName, records));
            }
        }
        
        return characters;
    }
    
    public void Dispose()
    {
        _cache.Clear();
    }
}

/// <summary>
/// 素質定義
/// </summary>
public record TalentDefinition(
    int Id,
    string Name,
    string Description
);

/// <summary>
/// 調教定義
/// </summary>
public record TrainDefinition(
    int Id,
    string Name
);

/// <summary>
/// キャラクター CSV データ
/// </summary>
public record CharacterCsvData(
    string FileName,
    List<IDictionary<string, string>> Records
);
