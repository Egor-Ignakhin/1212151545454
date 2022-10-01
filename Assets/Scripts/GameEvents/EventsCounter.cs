using System;

public static class EventsCounter
{
    private static int currentEventIndex = 0;

    private const int maxEventIndex = 1;
    public static event Action LastEventCompleted;
    
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
        }
    }
}