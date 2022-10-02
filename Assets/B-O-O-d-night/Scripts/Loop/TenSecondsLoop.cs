using System;
using System.Collections;
using UnityEngine;

public class TenSecondsLoop : MonoBehaviour
{
    public static event Action ValueChanged;
    public static event Action NewCycle;
    public static event Action OnMomeEntered;
    public static event Action OnMomeExit;
    public static float Timer { get; set; }

    private IEnumerator Start()
    {
        Timer = 0;
        while (true)
        {
            Timer += Time.deltaTime;
            ValueChanged?.Invoke();

            if (Timer > 10f)
            {
                NewCycle?.Invoke();
                var momeWatchingTime = 3f;
                OnMomeEntered?.Invoke();
                yield return new WaitForSeconds(momeWatchingTime);
                OnMomeExit?.Invoke();
                Timer = 0;
            }

            yield return null;
        }
    }
}