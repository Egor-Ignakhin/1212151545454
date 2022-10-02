using System;
using System.Collections.Generic;

public static class InventoryData
{
    public static event Action<ItemType> NewItemAdded;
    private static readonly Dictionary<ItemType, bool> pickedItems;

    static InventoryData()
    {
        pickedItems = new Dictionary<ItemType, bool>();

        var values = (ItemType[])Enum.GetValues(typeof(ItemType));
        foreach (var t in values) pickedItems.Add(t, false);
    }

    public static void AddItem(ItemType itemType)
    {
        pickedItems[itemType] = true;
        NewItemAdded?.Invoke(itemType);
    }

    public static void RemoveItem(ItemType itemType)
    {
        pickedItems[itemType] = false;
    }

    public static bool HasItem(ItemType type)
    {
        return pickedItems[type];
    }
}