using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsEventsUpdater : MonoBehaviour
{
    [SerializeField] private List<Image> starsImg = new();
    [SerializeField] private Sprite fullStart, emptyStar;

    private void Update()
    {
        Redraw();
    }

    private void Redraw()
    {
        for (var i = 0; i < starsImg.Count; i++)
        {
            var starIsReached = EventsCounter.CurrentEventIndex > i;
            starsImg[i].sprite = starIsReached ? fullStart : emptyStar;
        }
    }
}