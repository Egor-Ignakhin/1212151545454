using System;

public static class EventsCounter
{
    private static int currentEventIndex;

    public const int MaxEventIndex = 1;
    public static event Action LastEventCompleted;

    public static int CurrentEventIndex
    {
        get => currentEventIndex;
        set
        {
            if (value == MaxEventIndex)
            {
                LastEventCompleted?.Invoke();
                return;
            }

            currentEventIndex = value;
        }
    }
}