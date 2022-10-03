using UnityEngine;

public class TaskCompleteSoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator booAnimator;
    private static readonly int boo = Animator.StringToHash("Boo");
    [SerializeField] private ParticleSystem ps;

    private void Awake()
    {
        EventsCounter.EventChanged += EventsCounterOnEventChanged;
    }

    public void EventsCounterOnEventChanged()
    {
        ps.Play();
        audioSource.Play();
        booAnimator.SetTrigger(boo);
    }

    private void OnDestroy()
    {
        EventsCounter.EventChanged += EventsCounterOnEventChanged;
    }
}