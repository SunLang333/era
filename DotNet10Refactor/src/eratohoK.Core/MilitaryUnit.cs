namespace eratohoK.Core;

public class MilitaryUnit : IGameResource
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public int CountryId { get; set; }
    public int SoldierCount { get; set; }
    public List<int> CommanderIds { get; set; } = [];
    public int Position { get; set; }
    public int TargetCityId { get; set; }
}
