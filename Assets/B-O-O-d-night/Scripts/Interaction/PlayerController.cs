using TMPro;
using UnityEngine;

internal class PlayerController : MonoBehaviour
{
    public static bool IsCaught { get; set; }

    public bool IsInsideWardrobe { get; set; }

    [SerializeField] private Rigidbody2D mRigidbody;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private PlayerMoves playerMoves;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private GameObject inWardrobeUIGm;
    [SerializeField] private GameObject mLight;

    private Vector3 lastPreWardrobePosition;
    private float timerInWardrobe;


    public void OnEnable()
    {
        IsCaught = false;
    }

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
        mLight.SetActive(true);
        if (IsCaught || IsInsideWardrobe)
            mLight.SetActive(false);

        textMeshProUGUI.SetText(IsInsideWardrobe ? "Press E to exit" : "");
        if (IsInsideWardrobe)
        {
            timerInWardrobe += Time.deltaTime;
            if (timerInWardrobe > 1f)
            {
                if (Input.GetKeyDown(KeyCode.E)) MoveOutsideFromWardrobe();

                if (Input.touchCount > 1) MoveOutsideFromWardrobe();
            }
        }
    }

    public void ButtonClickCheck()
    {
        if (IsInsideWardrobe)
        {
            if(timerInWardrobe > 1f)
            {
                MoveOutsideFromWardrobe();
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