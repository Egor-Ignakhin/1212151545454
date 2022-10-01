using System.Collections.Generic;
using UnityEngine;

public class WardrobeDoorsEvent : GameEvent
{
    [SerializeField] private List<GameEventTrigger> mGameEventTrigger = new();
    private int calls;

    public override void Activate()
    {
        calls++;

        for (var i = 0; i < triggers.Count; i++)
        {
            if (!triggers[i].IsActive) continue;
            triggers.Remove(triggers[i]);
            i--;
        }

        if (calls == 2)
        {
            EventsCounter.CurrentEventIndex++;
        }
    }
}