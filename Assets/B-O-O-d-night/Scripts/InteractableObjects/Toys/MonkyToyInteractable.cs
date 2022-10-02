using System.Collections;
using UnityEngine;

public class MonkyToyInteractable : InteractableObject
{
    [SerializeField] private EventType eventType;
    [SerializeField] private AudioSource monkeySource;
    [SerializeField] private AudioClip keyInsertingClip;
    [SerializeField] private AudioClip gamingClip;
    public bool WasInteracted { get; set; }
    [SerializeField] private Monkey monkey;

    public override void Interact()
    {
        // Play sound
        monkeySource.PlayOneShot(keyInsertingClip);

        EventsCounter.CurrentEventIndex++;
        WasInteracted = true;

        StartCoroutine(PlayerGamingClip(keyInsertingClip.length));
        monkey.Animate();
    }

    public IEnumerator PlayerGamingClip(float s)
    {
        yield return new WaitForSeconds(s);
        monkeySource.PlayOneShot(gamingClip);
    }

    public override bool CanInteract()
    {
       return eventType == EventsCounter.CurrentEventType() && InventoryData.HasItem(ItemType.Key) && !WasInteracted;
    }
}