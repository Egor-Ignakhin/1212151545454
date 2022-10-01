using UnityEngine;

public class ProgressChecker : MonoBehaviour
{
    [SerializeField] private Darkness badDarkness, goodDarkness;

    private void Awake()
    {
        EventsCounter.LastEventCompleted += EventsCounterOnLastEventCompleted;
    }

    private void EventsCounterOnLastEventCompleted()
    {
        goodDarkness.ChangeScene();
    }

    private void OnDestroy()
    {
        EventsCounter.LastEventCompleted -= EventsCounterOnLastEventCompleted;
    }
}