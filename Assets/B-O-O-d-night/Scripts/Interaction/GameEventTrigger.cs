using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    public bool IsActive { get; set; }

    [SerializeField] protected EventType eventType;
    
    private void Awake()
    {
        EventsCounter.EventChanged += EventsCounterOnEventChanged;
        EventsCounterOnEventChanged();
    }

    private void OnDestroy()
    {
        EventsCounter.EventChanged -= EventsCounterOnEventChanged;
    }

    private void EventsCounterOnEventChanged()
    {
        GetComponent<Collider2D>().enabled = eventType == EventsCounter.CurrentEventType();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventoryInteraction playerInventoryInteraction))
        {
            playerInventoryInteraction.PossiblyEvent = gameEvent;
            IsActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventoryInteraction playerInventoryInteraction))
        {
            playerInventoryInteraction.PossiblyEvent = null;
            IsActive = false;
        }
    }
}