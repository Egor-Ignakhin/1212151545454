using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private EventType eventType;
    public ItemType PickUp()
    {
        gameObject.SetActive(false);

        return itemType;
    }

    public bool CanGet()
    {
        return EventsCounter.CurrentEventType() == eventType;
    }
}