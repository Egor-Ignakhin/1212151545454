using System;
using TMPro;
using UnityEngine;

internal class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mRigidbody;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private Vector3 lastPreWardrobePosition;
    private float timerInWardrobe;
    public bool IsInsideWardrobe { get; set; }
    public static bool IsCaught { get; set; }

    [SerializeField] private PlayerMoves playerMoves;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private GameObject inWardrobeUIGm;

    public void MoveInsideWardobe(Vector3 position)
    {
        lastPreWardrobePosition = transform.position;
        
        transform.position = position;
        mRigidbody.simulated = false;
        IsInsideWardrobe = true;
        timerInWardrobe = 0;
        playerMoves.ForbidMotion();
        playerSpriteRenderer.enabled = false;
        inWardrobeUIGm.SetActive(true);
    }

    private void Update()
    {
        textMeshProUGUI.SetText(IsInsideWardrobe? "Press E to exit" : "");
        if (IsInsideWardrobe)
        {
            timerInWardrobe += Time.deltaTime;
            if (timerInWardrobe > 1f)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MoveOutsideFromWardrobe();
                }
            }
        }
    }

    private void MoveOutsideFromWardrobe()
    {
        transform.position = lastPreWardrobePosition;
        mRigidbody.simulated = true;
        IsInsideWardrobe = false;
        timerInWardrobe = 0;
        playerMoves.AllowMotion();
        playerSpriteRenderer.enabled = true;
        inWardrobeUIGm.SetActive(false);
    }
}