using System;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    [SerializeField] private int speed = 300;

    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    [Obsolete]
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * (speed * Time.deltaTime);
            anim.SetInteger("Pose", 1);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.up * (speed * Time.deltaTime);
            anim.SetInteger("Pose", 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * (speed * Time.deltaTime);
            anim.SetInteger("Pose", 2);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * (speed * Time.deltaTime);
            anim.SetInteger("Pose", 2);
            transform.localScale = new Vector3(1, 1, 1);
        }

        GetInputFromMouse();
    }

    private void GetInputFromMouse()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var direction = mousePosition - (Vector2)transform.position;

            if (direction.magnitude > 1)
                direction = direction.normalized;

            transform.position += (Vector3)direction * (speed * Time.deltaTime);
            anim.SetInteger("Pose", 2);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}