using System;

public static class EventsCounter
{
    private static int currentEventIndex;

    private const int maxEventIndex = 5;
    public static event Action LastEventCompleted;
    public static event Action EventChanged;

    public static int CurrentEventIndex
    {
        get => currentEventIndex;
        set
        {
            if (value == maxEventIndex)
            {
                LastEventCompleted?.Invoke();
                return;
            }

            currentEventIndex = value;
            EventChanged?.Invoke();
        }
    }

    public static bool IsLastEvent => CurrentEventIndex == maxEventIndex;

    public static EventType CurrentEventType()
    {
        var eventType = ((EventType[])Enum.GetValues(typeof(EventType)))[currentEventIndex];

        return eventType;
    }
}