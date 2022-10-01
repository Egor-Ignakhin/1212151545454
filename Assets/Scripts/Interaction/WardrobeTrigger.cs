using UnityEngine;

public class WardrobeTrigger : MonoBehaviour
{
    [SerializeField] private WardrobeController wardrobeController;
    private void OnTriggerEnter2D(Collider2D col)
    {
        wardrobeController.MovePlayerInside();
    }
}