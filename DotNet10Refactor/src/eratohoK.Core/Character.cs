namespace eratohoK.Core;

/// <summary>
/// キャラクターエンティティ
/// ゲーム内のキャラクターを表す主要クラス
/// </summary>
public class Character : IGameResource
{
    // IGameResource implementation
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    // 基本情報
    public int No { get; set; }           // CSV 番号
    public string Nickname { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    
    // 所属関係
    public int CountryId { get; set; }        // 所属勢力 ID
    public int CityId { get; set; }           // 所在城市 ID
    public int PrisonerOfCountryId { get; set; } // 俘虏于哪个势力 (0=非俘虏)
    public SpecialState SpecialState { get; set; }
    
    // ステータス
    public BaseStatus BaseStatus { get; set; } = new();
    public Ability Ability { get; set; } = new();
    public Talent Talent { get; set; } = new();
    public Experience Experience { get; set; } = new();
    
    // 好感度システム
    public int Likeability { get; set; }      // 好感度
    public int Subordination { get; set; }    // 従属度
    public int Dependency { get; set; }       // 依存度
    
    // 装備
    public List<int> EquipmentIds { get; set; } = new();
    
    // スキル
    public List<Skill> Skills { get; set; } = new();
    
    // 関係
    public Dictionary<int, int> RelationsLike { get; set; } = new();   // 对其他角色的好感
    public Dictionary<int, int> RelationsHate { get; set; } = new();   // 对其他角色的厌恶
    
    // 状態标记
    public bool IsParticipatingInTraining { get; set; }
    public bool HasActed { get; set; }
    public ActionDisabledState ActionDisabledState { get; set; }
    
    // 性経験記録
    public SexualExperience? FirstExperienceRecord { get; set; }
    
    // 妊娠状態
    public bool IsPregnant { get; set; }
    public bool IsDangerDay { get; set; }
    public bool IsInLove { get; set; }      // 恋慕
    public bool IsLover { get; set; }       // 恋人
    
    /// <summary>
    /// 指定したキャラクターに対する好感度を取得
    /// </summary>
    public int GetLikeabilityTowards(int targetCharacterId)
    {
        return RelationsLike.TryGetValue(targetCharacterId, out var like) ? like : 0;
    }
    
    /// <summary>
    /// 指定したキャラクターに対する厌恶度を取得
    /// </summary>
    public int GetHateTowards(int targetCharacterId)
    {
        return RelationsHate.TryGetValue(targetCharacterId, out var hate) ? hate : 0;
    }
    
    /// <summary>
    /// 好感度を更新
    /// </summary>
    public void UpdateLikeability(int targetCharacterId, int delta)
    {
        if (!RelationsLike.ContainsKey(targetCharacterId))
        {
            RelationsLike[targetCharacterId] = 0;
        }
        RelationsLike[targetCharacterId] += delta;
    }
}

/// <summary>
/// 初体験記録
/// </summary>
public record SexualExperience(
    int? FirstVaginalPartnerId = null,
    int? FirstAnalPartnerId = null,
    int? FirstOralPartnerId = null,
    int? FirstHandPartnerId = null,
    int? FirstBreastPartnerId = null,
    DateTime? FirstVaginalDate = null,
    DateTime? FirstAnalDate = null,
    DateTime? FirstOralDate = null,
    DateTime? FirstHandDate = null,
    DateTime? FirstBreastDate = null
);

/// <summary>
/// スキル
/// </summary>
public record Skill(
    int Id,
    string Name,
    string Description,
    int Level = 1,
    double ActivationRate = 1.0
);
