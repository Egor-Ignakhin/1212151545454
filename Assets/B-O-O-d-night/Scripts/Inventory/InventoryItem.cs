using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private ItemType itemType;

    public ItemType PickUp()
    {
        gameObject.SetActive(false);

        return itemType;
    }
}