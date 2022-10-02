using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsEventsUpdater : MonoBehaviour
{
    [SerializeField] private List<Image> starsImg = new();
    [SerializeField] private Color unReachedColor;

    private void Update()
    {
        Redraw();
    }

    private void Redraw()
    {
        for (var i = 0; i < starsImg.Count; i++)
        {
            var starIsReached = EventsCounter.CurrentEventIndex > i;
            starsImg[i].color = starIsReached ? Color.white : unReachedColor;
        }
    }
}