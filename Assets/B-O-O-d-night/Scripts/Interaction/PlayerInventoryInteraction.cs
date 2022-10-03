using TMPro;
using UnityEngine;

public class PlayerInventoryInteraction : MonoBehaviour
{
    public GameEvent PossiblyEvent { get; set; }

    [SerializeField] private TextMeshProUGUI hintText;

    [SerializeField] private bool inputFromKeyboard = true;
    [SerializeField] private bool inputFromMouse = true;
    private InteractableObject interactiveObject;

    private void OnTriggerEnter2D(Collider2D col)
    {
        interactiveObject = null;
        if (col.TryGetComponent(out InventoryItem inventoryItem) && inventoryItem.CanGet())
            AddItemInInventory(inventoryItem);

        if (col.TryGetComponent(out InteractableObject interactableObject))
        {
            if (!interactableObject.CanInteract()) return;
            interactiveObject = interactableObject;
        }
    }

    private void AddItemInInventory(InventoryItem inventoryItem)
    {
        var itemType = inventoryItem.PickUp();
        InventoryData.AddItem(itemType);
    }

    private void Update()
    {
        hintText.SetText(PossiblyEvent || interactiveObject ? "Press E to interact" : "");

        if (interactiveObject)
        {
            if (inputFromKeyboard && Input.GetKeyDown(KeyCode.E))  InteractWithObject();
            if (inputFromMouse && Input.GetMouseButtonDown(1)) InteractWithObject();
        }
        
        if (PossiblyEvent)
        {
            if (inputFromKeyboard && Input.GetKeyDown(KeyCode.E)) StartPossiblyEvent();
            if (inputFromMouse && Input.GetMouseButtonDown(1)) StartPossiblyEvent();
        }
    }

    private void InteractWithObject()
    {
        interactiveObject.Interact();
        interactiveObject = null;
    }

    private void StartPossiblyEvent()
    {
        print("Event activated" + PossiblyEvent);

        PossiblyEvent.Activate();
    }
}