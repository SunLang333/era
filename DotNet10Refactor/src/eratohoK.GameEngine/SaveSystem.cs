namespace eratohoK.GameEngine;

using System.Text.Json;
using eratohoK.Core;

/// <summary>セーブデータ全体</summary>
public class SaveData
{
    public string Version { get; set; } = "1.0";
    public string SavedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    public int Day { get; set; }
    public DateTime CurrentDate { get; set; }
    public int PlayerCharacterId { get; set; }
    public List<int> TargetCharacterIds { get; set; } = [];
    public int PlayerCountryId { get; set; }
    public int PlayerGold { get; set; }
    public List<int> OwnedItemIds { get; set; } = [];
    public List<CharSave> Characters { get; set; } = [];
    public List<CountrySave> Countries { get; set; } = [];
    public List<CitySave> Cities { get; set; } = [];
}

/// <summary>キャラクターのセーブ用 DTO（ステータス類をフラット化）</summary>
public class CharSave
{
    public int Id { get; set; }
    public int No { get; set; }
    public string Name { get; set; } = "";
    public string Nickname { get; set; } = "";
    public string? Description { get; set; }
    public int GenderValue { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int PrisonerOfCountryId { get; set; }
    public int SpecialStateValue { get; set; }

    // BaseStatus
    public int Physical { get; set; } = 100;
    public int Mental { get; set; } = 100;
    public int Anger { get; set; }
    public int Sorrow { get; set; }
    public int Fear { get; set; }
    public int Joy { get; set; }
    public int Humiliation { get; set; }
    public int Corruption { get; set; }
    public int Resistance { get; set; }
    public int Obedience { get; set; }

    // Ability
    public int Desire { get; set; }
    public int SexualKnowledge { get; set; }
    public int Dominance { get; set; }
    public int Masochism { get; set; }
    public int Talk { get; set; }
    public int Heal { get; set; }
    public int Fight { get; set; }
    public int Magic { get; set; }
    public int Command { get; set; }
    public int Politics { get; set; }
    public int Intelligence { get; set; }

    // Talent flags (key ones tracked in game)
    public bool IsVirgin { get; set; } = true;
    public bool IsMaleVirgin { get; set; } = true;
    public bool IsAnalVirgin { get; set; } = true;
    public bool IsKissInexperienced { get; set; } = true;
    public bool IsRebellious { get; set; }
    public bool IsHonest { get; set; }
    public bool IsStoic { get; set; }
    public bool IsEasilyWet { get; set; }
    public bool IsHardlyWet { get; set; }
    public bool IsDevoted { get; set; }
    public bool IsWeakToPain { get; set; }
    public bool IsStrongToPain { get; set; }
    public bool IsCurious { get; set; }
    public bool IsOptimistic { get; set; }
    public bool IsTsundere { get; set; }
    public bool IsCowardly { get; set; }
    public bool IsProud { get; set; }
    public bool IsShy { get; set; }
    public bool IsShameless { get; set; }

    // Relations
    public List<IntKvp> LikeRelations { get; set; } = [];

    // State
    public int Likeability { get; set; }
    public int Subordination { get; set; }
    public int Dependency { get; set; }
    public bool IsPregnant { get; set; }
    public bool IsInLove { get; set; }
    public bool IsLover { get; set; }
    public bool HasActed { get; set; }

    public static CharSave From(Character c)
    {
        var save = new CharSave
        {
            Id = c.Id, No = c.No,
            Name = c.Name, Nickname = c.Nickname, Description = c.Description,
            GenderValue = (int)c.Gender,
            CountryId = c.CountryId, CityId = c.CityId,
            PrisonerOfCountryId = c.PrisonerOfCountryId,
            SpecialStateValue = (int)c.SpecialState,
            // BaseStatus
            Physical = c.BaseStatus.Physical, Mental = c.BaseStatus.Mental,
            Anger = c.BaseStatus.Anger, Sorrow = c.BaseStatus.Sorrow,
            Fear = c.BaseStatus.Fear, Joy = c.BaseStatus.Joy,
            Humiliation = c.BaseStatus.Humiliation, Corruption = c.BaseStatus.Corruption,
            Resistance = c.BaseStatus.Resistance, Obedience = c.BaseStatus.Obedience,
            // Ability
            Desire = c.Ability.Desire, SexualKnowledge = c.Ability.SexualKnowledge,
            Dominance = c.Ability.Dominance, Masochism = c.Ability.Masochism,
            Talk = c.Ability.Talk, Heal = c.Ability.Heal,
            Fight = c.Ability.Fight, Magic = c.Ability.Magic,
            Command = c.Ability.Command, Politics = c.Ability.Politics,
            Intelligence = c.Ability.Intelligence,
            // Talent
            IsVirgin = c.Talent.IsVirgin, IsMaleVirgin = c.Talent.IsMaleVirgin,
            IsAnalVirgin = c.Talent.IsAnalVirgin, IsKissInexperienced = c.Talent.IsKissInexperienced,
            IsRebellious = c.Talent.IsRebellious, IsHonest = c.Talent.IsHonest,
            IsStoic = c.Talent.IsStoic, IsEasilyWet = c.Talent.IsEasilyWet,
            IsHardlyWet = c.Talent.IsHardlyWet, IsDevoted = c.Talent.IsDevoted,
            IsWeakToPain = c.Talent.IsWeakToPain, IsStrongToPain = c.Talent.IsStrongToPain,
            IsCurious = c.Talent.IsCurious, IsOptimistic = c.Talent.IsOptimistic,
            IsTsundere = c.Talent.IsTsundere, IsCowardly = c.Talent.IsCowardly,
            IsProud = c.Talent.IsProud, IsShy = c.Talent.IsShy, IsShameless = c.Talent.IsShameless,
            // State
            Likeability = c.Likeability, Subordination = c.Subordination, Dependency = c.Dependency,
            IsPregnant = c.IsPregnant, IsInLove = c.IsInLove, IsLover = c.IsLover, HasActed = c.HasActed,
            // Relations
            LikeRelations = c.RelationsLike.Select(kv => new IntKvp { K = kv.Key, V = kv.Value }).ToList()
        };
        return save;
    }

    public Character ToCharacter()
    {
        var ch = new Character
        {
            Id = Id, No = No,
            Name = Name, Nickname = Nickname, Description = Description,
            Gender = (Gender)GenderValue,
            CountryId = CountryId, CityId = CityId,
            PrisonerOfCountryId = PrisonerOfCountryId,
            SpecialState = (SpecialState)SpecialStateValue,
            BaseStatus = new BaseStatus(
                Physical: Physical, Mental: Mental,
                Anger: Anger, Sorrow: Sorrow, Fear: Fear, Joy: Joy,
                Humiliation: Humiliation, Corruption: Corruption,
                Resistance: Resistance, Obedience: Obedience),
            Ability = new Ability(
                Desire: Desire, SexualKnowledge: SexualKnowledge, Dominance: Dominance,
                Masochism: Masochism, Talk: Talk, Heal: Heal, Fight: Fight,
                Magic: Magic, Command: Command, Politics: Politics, Intelligence: Intelligence),
            Talent = new Talent(
                Gender: (Gender)GenderValue,
                IsVirgin: IsVirgin, IsMaleVirgin: IsMaleVirgin,
                IsAnalVirgin: IsAnalVirgin, IsKissInexperienced: IsKissInexperienced,
                IsRebellious: IsRebellious, IsHonest: IsHonest, IsStoic: IsStoic,
                IsEasilyWet: IsEasilyWet, IsHardlyWet: IsHardlyWet, IsDevoted: IsDevoted,
                IsWeakToPain: IsWeakToPain, IsStrongToPain: IsStrongToPain,
                IsCurious: IsCurious, IsOptimistic: IsOptimistic, IsTsundere: IsTsundere,
                IsCowardly: IsCowardly, IsProud: IsProud, IsShy: IsShy, IsShameless: IsShameless),
            Likeability = Likeability, Subordination = Subordination, Dependency = Dependency,
            IsPregnant = IsPregnant, IsInLove = IsInLove, IsLover = IsLover, HasActed = HasActed
        };
        foreach (var kv in LikeRelations)
            ch.RelationsLike[kv.K] = kv.V;
        return ch;
    }
}

/// <summary>JSON シリアライズ用の int→int ペア</summary>
public class IntKvp { public int K { get; set; } public int V { get; set; } }

/// <summary>勢力のセーブ用 DTO</summary>
public class CountrySave
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public int BossCharacterId { get; set; }
    public string Color { get; set; } = "#FFFFFF";
    public int SoldierCount { get; set; }
    public int EconomyScale { get; set; }
    public bool IsAIControlled { get; set; }
    public bool IsDestroyed { get; set; }
    public List<int> CityIds { get; set; } = [];
    public List<int> CharacterIds { get; set; } = [];

    public static CountrySave From(Country c) => new()
    {
        Id = c.Id, Name = c.Name, Description = c.Description,
        BossCharacterId = c.BossCharacterId, Color = c.Color,
        SoldierCount = c.SoldierCount, EconomyScale = c.EconomyScale,
        IsAIControlled = c.IsAIControlled, IsDestroyed = c.IsDestroyed,
        CityIds = c.CityIds.ToList(), CharacterIds = c.CharacterIds.ToList()
    };

    public Country ToCountry() => new()
    {
        Id = Id, Name = Name, Description = Description,
        BossCharacterId = BossCharacterId, Color = Color,
        SoldierCount = SoldierCount, EconomyScale = EconomyScale,
        IsAIControlled = IsAIControlled, IsDestroyed = IsDestroyed,
        CityIds = CityIds.ToList(), CharacterIds = CharacterIds.ToList()
    };
}

/// <summary>都市のセーブ用 DTO</summary>
public class CitySave
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int CountryId { get; set; }
    public int Defense { get; set; }
    public int Population { get; set; }
    public int Gold { get; set; }
    public int Food { get; set; }
    public List<int> StationedCharacterIds { get; set; } = [];

    public static CitySave From(City c) => new()
    {
        Id = c.Id, Name = c.Name, CountryId = c.CountryId,
        Defense = c.Defense, Population = c.Population,
        Gold = c.Gold, Food = c.Food,
        StationedCharacterIds = c.StationedCharacterIds.ToList()
    };

    public City ToCity() => new()
    {
        Id = Id, Name = Name, CountryId = CountryId,
        Defense = Defense, Population = Population, Gold = Gold, Food = Food,
        StationedCharacterIds = StationedCharacterIds.ToList()
    };
}

/// <summary>セーブ・ロードシステム</summary>
public class SaveSystem
{
    private const string SaveDirectory = "saves";
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    /// <summary>指定スロットにセーブする</summary>
    public bool Save(SaveData data, int slot = 0)
    {
        try
        {
            Directory.CreateDirectory(SaveDirectory);
            File.WriteAllText(GetSavePath(slot), JsonSerializer.Serialize(data, Options));
            return true;
        }
        catch { return false; }
    }

    /// <summary>指定スロットからロードする</summary>
    public SaveData? Load(int slot = 0)
    {
        try
        {
            var path = GetSavePath(slot);
            if (!File.Exists(path)) return null;
            return JsonSerializer.Deserialize<SaveData>(File.ReadAllText(path), Options);
        }
        catch { return null; }
    }

    public bool HasSave(int slot = 0) => File.Exists(GetSavePath(slot));

    /// <summary>存在するセーブスロット一覧を返す</summary>
    public List<(int Slot, SaveData Data)> ListSaves()
    {
        var result = new List<(int, SaveData)>();
        for (int i = 0; i < 5; i++)
        {
            var d = Load(i);
            if (d != null) result.Add((i, d));
        }
        return result;
    }

    private static string GetSavePath(int slot) =>
        Path.Combine(SaveDirectory, $"save{slot:D2}.json");
}
