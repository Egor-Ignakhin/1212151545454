using UnityEngine;

public class WardrobeDoorsEvent : GameEvent
{
    private int calls;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public override void Activate()
    {
        calls++;

        // Play audio
        audioSource.PlayOneShot(audioClip);

        //Play animation
        //...

        for (var i = 0; i < triggers.Count; i++)
        {
            if (!triggers[i].IsActive) continue;
            triggers[i].gameObject.SetActive(false);
            triggers.Remove(triggers[i--]);
        }

        if (calls == 3) EventsCounter.CurrentEventIndex++;
    }
}