using System.Collections.Generic;
using UnityEngine;

public class OpenWindowEvent : GameEvent
{
    [SerializeField] private List<GameEventTrigger> mGameEventTrigger = new();

    public override void Activate()
    {
        mGameEventTrigger.ForEach(trig => trig.gameObject.SetActive(false));

        EventsCounter.CurrentEventIndex++;
    }
}