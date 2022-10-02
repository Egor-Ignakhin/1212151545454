using System.Collections;
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
        StartCoroutine(Finishing());
    }

    private IEnumerator Finishing()
    {
        yield return StartCoroutine(Waiting());
        
        goodDarkness.ChangeScene();
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(6f);
    }

    public void MoveToBadScreen()
    {
        badDarkness.ChangeScene();
    }

    private void OnDestroy()
    {
        EventsCounter.LastEventCompleted -= EventsCounterOnLastEventCompleted;
    }
}