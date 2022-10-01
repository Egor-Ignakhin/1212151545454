using UnityEngine;
using UnityEngine.UI;

public class LoopTimerUpdater : MonoBehaviour
{
    [SerializeField] private Image circle;

    private void Awake()
    {
        TenSecondsLoop.ValueChanged += UpdateTimer;
    }

    private void UpdateTimer()
    {
        circle.fillAmount = 1 - TenSecondsLoop.Timer / 10f;
    }

    private void OnDestroy()
    {
        TenSecondsLoop.ValueChanged -= UpdateTimer;
    }
}