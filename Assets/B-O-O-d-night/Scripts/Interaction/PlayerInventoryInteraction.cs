using TMPro;
using UnityEngine;

public class PlayerInventoryInteraction : MonoBehaviour
{
    public GameEvent PossiblyEvent { get; set; }

    [SerializeField] private TextMeshProUGUI hintText;

    [SerializeField] private bool inputFromKeyboard = true;
    [SerializeField] private bool inputFromMouse = true;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out InventoryItem inventoryItem))
        {
            var itemType = inventoryItem.PickUp();
            InventoryData.AddItem(itemType);
        }

        if (col.TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.Interact();
        }
    }

    private void Update()
    {
        hintText.SetText(PossiblyEvent ? "Press E to interact" : "");

        if (PossiblyEvent)
        {
            if (inputFromKeyboard && Input.GetKeyDown(KeyCode.E)) StartPossiblyEvent();
            if (inputFromMouse &&  Input.GetMouseButtonDown(1)) StartPossiblyEvent();
        }
    }

    private void StartPossiblyEvent()
    {
        print("Event activated" + PossiblyEvent);

        PossiblyEvent.Activate();
    }
}