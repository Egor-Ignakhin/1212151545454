using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public bool isStatic;
    public float offset;
    private readonly int sortingOrdegBase = 0;
    private new Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrdegBase - transform.position.y + offset);

        if (isStatic)
            Destroy(this);
    }
}