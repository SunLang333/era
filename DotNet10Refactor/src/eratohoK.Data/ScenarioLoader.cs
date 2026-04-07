namespace eratohoK.Data;

public class ScenarioDefinition
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<ScenarioFaction> Factions { get; set; } = [];
}

public class ScenarioFaction
{
    public string Name { get; set; } = "";
    public int EconomyScale { get; set; }
    public int SoldierCount { get; set; }
    public List<string> StartingTechs { get; set; } = [];
}

public class ScenarioLoader
{
    public static List<ScenarioDefinition> GetBuiltInScenarios() =>
    [
        new ScenarioDefinition
        {
            Id = 1, Name = "大妖精戦争", Description = "三勢力が幻想郷の覇権を争う。",
            Factions =
            [
                new ScenarioFaction { Name = "博麗神社", EconomyScale = 300, SoldierCount = 50 },
                new ScenarioFaction { Name = "霧の湖",   EconomyScale = 200, SoldierCount = 30 },
                new ScenarioFaction { Name = "紅魔館",   EconomyScale = 500, SoldierCount = 100 }
            ]
        },
        new ScenarioDefinition
        {
            Id = 2, Name = "幻想郷統一戦", Description = "五勢力が覇権をめぐり激突する。",
            Factions =
            [
                new ScenarioFaction { Name = "博麗神社", EconomyScale = 300, SoldierCount = 50 },
                new ScenarioFaction { Name = "霧の湖",   EconomyScale = 200, SoldierCount = 30 },
                new ScenarioFaction { Name = "紅魔館",   EconomyScale = 500, SoldierCount = 100 },
                new ScenarioFaction { Name = "人間の里", EconomyScale = 150, SoldierCount = 20 },
                new ScenarioFaction { Name = "妖怪の山", EconomyScale = 400, SoldierCount = 80 }
            ]
        },
        new ScenarioDefinition
        {
            Id = 3, Name = "魔界侵攻", Description = "幻想郷連合対魔界の決戦。",
            Factions =
            [
                new ScenarioFaction { Name = "幻想郷連合", EconomyScale = 600, SoldierCount = 150 },
                new ScenarioFaction { Name = "魔界",       EconomyScale = 800, SoldierCount = 200 }
            ]
        }
    ];
}
