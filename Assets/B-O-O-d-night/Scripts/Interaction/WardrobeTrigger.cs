using TMPro;
using UnityEngine;

public class WardrobeTrigger : MonoBehaviour
{
    [SerializeField] private WardrobeController wardrobeController;
    private bool isControllerHere;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private void OnTriggerEnter2D(Collider2D col)
    {
        isControllerHere = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        isControllerHere = false;
    }

    private void FixedUpdate()
    {
        textMeshProUGUI.SetText(isControllerHere ? "Press E to enter" : "");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isControllerHere) wardrobeController.MovePlayerInside();
    }
}