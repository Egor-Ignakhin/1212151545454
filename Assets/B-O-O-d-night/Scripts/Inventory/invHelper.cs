using UnityEngine;

public class invHelper : MonoBehaviour
{
    private void Awake()
    {
        InventoryData.FillInventoryOnStarting();
    }
}