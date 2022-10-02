public class CoatAndHatEvent : GameEvent
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
        if (InventoryData.HasItem(ItemType.Coat) &&
            InventoryData.HasItem(ItemType.Hat))
            print("on coat and hat pickup");
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