using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    public bool IsActive { get; set; }

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