using UnityEngine;

public class TaskCompleteSoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator booAnimator;
    [SerializeField] private ParticleSystem ps;
    private static readonly int boo = Animator.StringToHash("Boo");

    private void OnEnable()
    {
        EventsCounter.EventChanged += EventsCounterOnEventChanged;
    }

    private void EventsCounterOnEventChanged()
    {
        ps.Play();
        audioSource.Play();
        booAnimator.SetTrigger(boo);
    }

    private void OnDisable()
    {
        EventsCounter.EventChanged -= EventsCounterOnEventChanged;
    }
}