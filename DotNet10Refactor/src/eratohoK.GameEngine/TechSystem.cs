namespace eratohoK.GameEngine;

using eratohoK.Core;

public static class TechSystem
{
    private static readonly Dictionary<string, string[]> Prerequisites = new()
    {
        ["BasicFarming"]    = [],
        ["AdvancedFarming"] = ["BasicFarming"],
        ["CombatDoctrine"]  = [],
        ["Fortification"]   = [],
        ["Logistics"]       = []
    };

    private static readonly Dictionary<string, string> Descriptions = new()
    {
        ["BasicFarming"]    = "基礎農業（経済+10%）",
        ["AdvancedFarming"] = "高度農業（経済+20%、要:基礎農業）",
        ["CombatDoctrine"]  = "戦術理論（戦闘力+20%）",
        ["Fortification"]   = "築城術（都市防御+50相当）",
        ["Logistics"]       = "兵站（行動回数+1）"
    };

    public static bool CanResearch(Country country, string techId)
    {
        if (country.HasTechnology(techId)) return false;
        if (!Prerequisites.TryGetValue(techId, out var prereqs)) return false;
        return prereqs.All(p => country.HasTechnology(p));
    }

    public static void Research(Country country, string techId)
    {
        if (CanResearch(country, techId))
            country.ResearchTechnology(techId);
    }

    public static double GetCombatBonus(Country country)
        => country.HasTechnology("CombatDoctrine") ? 0.2 : 0.0;

    public static double GetEconomyBonus(Country country)
    {
        double bonus = 0.0;
        if (country.HasTechnology("BasicFarming"))    bonus += 0.10;
        if (country.HasTechnology("AdvancedFarming")) bonus += 0.20;
        return bonus;
    }

    public static IReadOnlyDictionary<string, string> GetAllTechDescriptions() => Descriptions;
}
