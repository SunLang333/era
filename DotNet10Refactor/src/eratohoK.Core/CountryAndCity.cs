namespace eratohoK.Core;

/// <summary>
/// 勢力 (Country) エンティティ
/// </summary>
public class Country : IGameResource
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public int BossCharacterId { get; set; }      // 君主角色 ID
    public string Color { get; set; } = "#FFFFFF"; // 势力颜色
    public int SoldierCount { get; set; }          // 士兵数
    public int EconomyScale { get; set; }          // 经济规模
    
    // 科技樹
    public Dictionary<string, bool> Technologies { get; set; } = new();
    
    public bool IsAIControlled { get; set; }
    public bool IsDestroyed { get; set; }
    
    // 所属都市
    public List<int> CityIds { get; set; } = new();
    
    // 所属キャラクター
    public List<int> CharacterIds { get; set; } = new();
    
    /// <summary>
    /// 技術の研究状態を更新
    /// </summary>
    public void ResearchTechnology(string technologyId)
    {
        if (!Technologies.ContainsKey(technologyId))
        {
            Technologies[technologyId] = true;
        }
    }
    
    /// <summary>
    /// 技術が研究済みか確認
    /// </summary>
    public bool HasTechnology(string technologyId)
    {
        return Technologies.TryGetValue(technologyId, out var researched) && researched;
    }
}

/// <summary>
/// 都市 (City) エンティティ
/// </summary>
public class City : IGameResource
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public int CountryId { get; set; }           // 所属勢力 ID
    public int Defense { get; set; }             // 防御力
    public int Population { get; set; }          // 人口
    public int Gold { get; set; }                // 金銭
    public int Food { get; set; }                // 食糧
    
    // 施設
    public List<Facility> Facilities { get; set; } = new();
    
    // 駐留キャラクター
    public List<int> StationedCharacterIds { get; set; } = new();
    
    /// <summary>
    /// 施設を追加
    /// </summary>
    public void AddFacility(Facility facility)
    {
        Facilities.Add(facility);
    }
    
    /// <summary>
    /// 指定した種類の施設を取得
    /// </summary>
    public Facility? GetFacilityByType(FacilityType type)
    {
        return Facilities.FirstOrDefault(f => f.Type == type);
    }
}

/// <summary>
/// 施設の種類
/// </summary>
public enum FacilityType
{
    Barracks,       // 兵舎
    Farm,           // 農場
    Market,         // 市場
    Workshop,       // 工房
    ResearchLab,    // 研究所
    Hospital,       // 病院
    TrainingGround, // 訓練場
    Prison          // 牢獄
}

/// <summary>
/// 施設エンティティ
/// </summary>
public record Facility(
    int Id,
    string Name,
    FacilityType Type,
    int Level = 1,
    int Capacity = 0
);
