using UnityEngine;

public class CoatAndHatEvent : GameEvent
{
    [SerializeField] private GameObject allClothGm;
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
        
        allClothGm.SetActive(true);
    }
}