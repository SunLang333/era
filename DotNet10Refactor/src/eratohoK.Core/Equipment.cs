namespace eratohoK.Core;

public class Equipment : IGameResource
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public EquipmentSlot Slot { get; set; }
    public List<TrainingActionType> BlockedActions { get; set; } = [];
    public int JoyBonus { get; set; }
}

public enum EquipmentSlot { Top, Bottom, Legs, Accessory, Restraint }
