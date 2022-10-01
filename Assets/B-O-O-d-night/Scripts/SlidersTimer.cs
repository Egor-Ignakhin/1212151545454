using UnityEngine;
using UnityEngine.UI;

public class SlidersTimer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;
    private bool stopTimer;

    // Start is called before the first frame update
    private void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    private void Update()
    {
        var time = gameTime = Time.time;
        var minutes = Mathf.FloorToInt(time / 60);
        var seconds = Mathf.FloorToInt(time - minutes / 60);
        var textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0) stopTimer = true;
        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;
        }
    }
}