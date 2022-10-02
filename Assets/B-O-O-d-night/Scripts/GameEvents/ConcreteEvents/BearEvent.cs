using System;

public class BearEvent : GameEvent
{
    private void Awake()
    {
        InventoryData.NewItemAdded += InventoryDataOnNewItemAdded;
    }

    private void OnDestroy()
    {
        InventoryData.NewItemAdded -= InventoryDataOnNewItemAdded;
    }

    private void InventoryDataOnNewItemAdded(ItemType obj)
    {
        if (obj == ItemType.Bear) print("on bear pickup");
    }

    public override void Activate()
    {
        InventoryData.RemoveItem(ItemType.Bear);

        for (var i = 0; i < triggers.Count; i++)
        {
            if (!triggers[i].IsActive) continue;
            triggers.Remove(triggers[i]);
            i--;
        }

        EventsCounter.CurrentEventIndex++;
    }
}