using UnityEngine;

public class GameEvent : MonoBehaviour
{
    [SerializeField] private GameEventTrigger mGameEventTrigger;
    public virtual void Activate()
    {
        mGameEventTrigger.gameObject.SetActive(false);

        EventsCounter.CurrentEventIndex++;
    }
  
}