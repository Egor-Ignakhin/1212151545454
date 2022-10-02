using UnityEngine;

public class WindowDogWowController : MonoBehaviour
{
    [SerializeField] private AudioSource mSource;
    [SerializeField] private OpenWindowEvent openWindowEvent;

    private void Awake()
    {
        openWindowEvent.Finished += OpenWindowFinished;
    }

    private void OpenWindowFinished()
    {
        mSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (EventsCounter.CurrentEventIndex > 0)
            if (!mSource.isPlaying)
                mSource.Play();
    }
}