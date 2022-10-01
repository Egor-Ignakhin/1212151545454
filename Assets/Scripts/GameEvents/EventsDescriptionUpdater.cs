using System;
using UnityEngine;

public class EventsDescriptionUpdater : MonoBehaviour
{
    [SerializeField] private EventDescriptionData eventDescriptionData;
    private void Awake()
    {
        EventsCounter.LastEventCompleted += EventsCounterOnLastEventCompleted;
    }

    private void EventsCounterOnLastEventCompleted()
    {
        eventDescriptionData.GetDescriptionByEventIndex(EventsCounter.CurrentEventIndex, EventsCounter.MaxEventIndex);
    }
}