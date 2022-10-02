using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private ParticleSystem pt;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<PlayerInventoryInteraction>())
        {
            // Тут вставить звук MonkeyTishTish
            anim.SetTrigger("TishTish");
            pt.Play();
        }
    }
}
