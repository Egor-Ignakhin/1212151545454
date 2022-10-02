using UnityEngine;

public class TaskCompleteSoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator booAnimator;
    private static readonly int boo = Animator.StringToHash("Boo");

    private void Awake()
    {
        EventsCounter.EventChanged += EventsCounterOnEventChanged;
    }

    private void EventsCounterOnEventChanged()
    {
        audioSource.Play();
        booAnimator.SetTrigger(boo);
    }

    private void OnDestroy()
    {
        EventsCounter.EventChanged += EventsCounterOnEventChanged;
    }
}