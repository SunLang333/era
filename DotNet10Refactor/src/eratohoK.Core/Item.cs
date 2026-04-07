namespace eratohoK.Core;

/// <summary>アイテム</summary>
public record Item(int Id, string Name, string Description = "");

/// <summary>ショップで購入できるアイテム</summary>
public record ShopItem(
    int Id,
    string Name,
    int Price,
    string Description = "",
    /// <summary>購入後に適用されるステータスボーナス名（例: "Joy", "Obedience"）</summary>
    string StatBonus = "",
    int StatBonusValue = 0,
    /// <summary>特殊効果フラグ（例: "Virgin", "AnalVirgin", "KissVirgin" を解除）</summary>
    string SpecialEffect = "");

/// <summary>プレイヤーが所持するアイテムスロット</summary>
public class PlayerInventory
{
    private readonly Dictionary<int, int> _items = new();

    public void AddItem(int itemId, int count = 1)
    {
        _items[itemId] = _items.GetValueOrDefault(itemId) + count;
    }

    public bool UseItem(int itemId)
    {
        if (!_items.TryGetValue(itemId, out var count) || count <= 0)
            return false;
        _items[itemId] = count - 1;
        if (_items[itemId] == 0) _items.Remove(itemId);
        return true;
    }

    public int GetCount(int itemId) => _items.GetValueOrDefault(itemId);

    public IReadOnlyDictionary<int, int> Items => _items;

    public bool HasItem(int itemId) => GetCount(itemId) > 0;
}
