using UnityEngine;
using UnityEngine.UI;

public class LoopTimerUpdater : MonoBehaviour
{
    [SerializeField] private Image circle;
    [SerializeField] private AudioSource DoorSource;
    [SerializeField] private AudioSource stepsSource;
    
    
    private void Awake()
    {
        TenSecondsLoop.ValueChanged += UpdateTimer;
        TenSecondsLoop.NewCycle += TenSecondsLoopOnNewCycle;
    }

    private void TenSecondsLoopOnNewCycle()
    {
        DoorSource.Play();
    }

    private void UpdateTimer()
    {
        circle.fillAmount = 1 - TenSecondsLoop.Timer / 10f;

        if (circle.fillAmount < 0.2f)
        {
            if (!stepsSource.isPlaying)
            {
                stepsSource.Play();
            }
        }
    }

    private void OnDestroy()
    {
        TenSecondsLoop.ValueChanged -= UpdateTimer;
        TenSecondsLoop.NewCycle -= TenSecondsLoopOnNewCycle;
    }
}