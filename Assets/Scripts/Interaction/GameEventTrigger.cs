using System;
using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventoryInteraction playerInventoryInteraction))
        {
            playerInventoryInteraction.PossiblyEvent = gameEvent;

        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventoryInteraction playerInventoryInteraction))
        {
            playerInventoryInteraction.PossiblyEvent = null;
        }
    }
}