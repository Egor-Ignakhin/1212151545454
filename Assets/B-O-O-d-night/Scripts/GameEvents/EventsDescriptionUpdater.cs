using System;
using TMPro;
using UnityEngine;

public class EventsDescriptionUpdater : MonoBehaviour
{
    [SerializeField] private EventDescriptionData eventDescriptionData;
    [SerializeField] private TextMeshProUGUI descriptionText;
    private void Awake()
    {
        EventsCounter.EventChanged += EventsCounterOnEventChanged;
        EventsCounterOnEventChanged();
    }

    private void EventsCounterOnEventChanged()
    {
        var eventType = ((EventType[])Enum.GetValues(typeof(EventType)))[EventsCounter.CurrentEventIndex];
        var description = eventDescriptionData.GetDescription(eventType, EventsCounter.IsLastEvent, true);
        
        descriptionText.SetText(description);
    }

    private void OnDestroy()
    {
        EventsCounter.EventChanged -= EventsCounterOnEventChanged;
    }
}