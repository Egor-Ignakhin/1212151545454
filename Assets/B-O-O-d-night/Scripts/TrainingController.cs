using UnityEngine;

public class TrainingController : MonoBehaviour
{
    [SerializeField] private OpenWindowEvent openWindowEvent;

    [SerializeField] private Transform playerTr;
    [SerializeField] private Transform windowTr;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform closetDoor;
    [SerializeField] private PlayerController playerController;

    private Transform target;

    private void Awake()
    {
        target = windowTr;
        target.gameObject.SetActive(true);

        openWindowEvent.Finished += OnWindowOpened;
    }

    private void Update()
    {
        if (lineRenderer.enabled)
        {
            lineRenderer.SetPosition(0, playerTr.position);
            lineRenderer.SetPosition(1, target.position);
        }

        if (playerController.IsInsideWardrobe)
        {
            lineRenderer.enabled = false;
            OnDestroy();
            target.gameObject.SetActive(false);
        }
    }

    private void OnWindowOpened()
    {
        target.gameObject.SetActive(false);

        target = closetDoor;
        target.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        openWindowEvent.Finished -= OnWindowOpened;
    }
}