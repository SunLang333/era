namespace eratohoK.GameEngine;

using eratohoK.Core;

public static class ClothingSystem
{
    public static bool IsActionBlocked(Character target, TrainingActionType action)
        => target.EquippedItems.Any(e => e.BlockedActions.Contains(action));

    public static void Equip(Character character, Equipment item)
    {
        character.EquippedItems.RemoveAll(e => e.Slot == item.Slot);
        character.EquippedItems.Add(item);
        if (!character.EquipmentIds.Contains(item.Id))
            character.EquipmentIds.Add(item.Id);
    }

    public static void Unequip(Character character, int equipmentId)
    {
        character.EquippedItems.RemoveAll(e => e.Id == equipmentId);
        character.EquipmentIds.Remove(equipmentId);
    }

    public static IReadOnlyList<Equipment> GetEquipped(Character character)
        => character.EquippedItems.AsReadOnly();
}
