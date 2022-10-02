using UnityEngine;

public class MonkyToyInteractable : InteractableObject
{
    [SerializeField] private EventType eventType;
    

    public override void Interact()
    {
        // Play sound
        // ...

        // Play animation
        // ...

        print("monkey interacted");
        gameObject.SetActive(false);
        EventsCounter.CurrentEventIndex++;
    }

    public override bool CanInteract()
    {
       return eventType == EventsCounter.CurrentEventType() && InventoryData.HasItem(ItemType.Key);
    }
}