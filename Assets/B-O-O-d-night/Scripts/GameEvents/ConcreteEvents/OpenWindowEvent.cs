using System.Collections.Generic;
using UnityEngine;

public class OpenWindowEvent : GameEvent
{
    [SerializeField] private List<GameEventTrigger> mGameEventTrigger = new();
    [SerializeField] private AudioSource windLoopSource;
    [SerializeField] private SpriteRenderer closed, opened;

    public override void Activate()
    {
        windLoopSource.Play();
        
        mGameEventTrigger.ForEach(trig => trig.gameObject.SetActive(false));

        EventsCounter.CurrentEventIndex++;

        Finished?.Invoke();
        closed.enabled = false;
        opened.enabled = true;
    }
}