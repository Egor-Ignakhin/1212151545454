using TMPro;
using UnityEngine;

public class PlayerInventoryInteraction : MonoBehaviour
{
    public GameEvent PossiblyEvent { get; set; }

    [SerializeField] private TextMeshProUGUI hintText;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out InventoryItem inventoryItem))
        {
            var itemType = inventoryItem.PickUp();
            InventoryData.AddItem(itemType);
        }

        hintText.SetText(PossiblyEvent ? "Press E to interact" : "");
    }
}