using System;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    [SerializeField] private int speed = 300;

    private Animator anim;
    private static readonly int pose = Animator.StringToHash("Pose");

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    [Obsolete]
    private void Update()
    {
        GetInputFromKeyboard();

        GetInputFromMouse();
    }

    private void GetInputFromKeyboard()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = -Input.GetAxis("Horizontal");

        MoveByDirection(new Vector2(horizontal, vertical));
    }

    private void GetInputFromMouse()
    {
        if (!Input.GetMouseButton(0)) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var direction = mousePosition - (Vector2)transform.position;

        if (direction.magnitude > 1)
            direction = direction.normalized;

        var vertical = direction.y;
        var horizontal = -direction.x;
            
        MoveByDirection(new Vector2(horizontal, vertical));
    }

    private void MoveByDirection(Vector2 direction)
    {
        if (direction.y != 0)
        {
            transform.position += transform.up * (speed * Time.deltaTime * direction.y);
            anim.SetInteger(pose, direction.y > 0 ? 1 : 0);
        }

        if (direction.x != 0)
        {
            transform.position -= transform.right * (speed * Time.deltaTime * direction.x);
            anim.SetInteger(pose, 2);
            transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
        }
    }
}