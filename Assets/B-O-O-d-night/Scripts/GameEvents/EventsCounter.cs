using System;

public static class EventsCounter
{
    private static int currentEventIndex;

    private const int maxEventIndex = 2;
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
}