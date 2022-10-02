using System.Collections;
using UnityEngine;

public class MonkyToyInteractable : InteractableObject
{
    [SerializeField] private EventType eventType;
    [SerializeField] private AudioSource monkeySource;
    [SerializeField] private AudioClip keyInsertingClip;
    [SerializeField] private AudioClip gamingClip;
    private bool wasInteracted;

    public override void Interact()
    {
        // Play sound
        monkeySource.PlayOneShot(keyInsertingClip);

        // Play animation
        // ...

        EventsCounter.CurrentEventIndex++;
        wasInteracted = true;

        StartCoroutine(PlayerGamingClip(keyInsertingClip.length));
    }

    private IEnumerator PlayerGamingClip(float s)
    {
        yield return new WaitForSeconds(s);
        monkeySource.PlayOneShot(gamingClip);
    }

    public override bool CanInteract()
    {
       return eventType == EventsCounter.CurrentEventType() && InventoryData.HasItem(ItemType.Key) && !wasInteracted;
    }
}