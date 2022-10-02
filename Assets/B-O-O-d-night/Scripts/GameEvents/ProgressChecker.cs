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
        //Set here finish coroutine
        //yield return yourCoroutine;
        
        yield return null;
        
        goodDarkness.ChangeScene();
    }

    private void OnDestroy()
    {
        EventsCounter.LastEventCompleted -= EventsCounterOnLastEventCompleted;
    }
}