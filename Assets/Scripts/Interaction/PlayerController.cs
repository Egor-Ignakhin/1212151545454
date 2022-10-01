using UnityEngine;

internal class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mRigidbody;

    public void MoveInsideWardobe(Vector3 position)
    {
        transform.position = position;
        mRigidbody.simulated = false;
    }
}