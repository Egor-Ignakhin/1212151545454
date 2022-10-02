using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{

    private Animator anim;
    [SerializeField] private ParticleSystem pt;

    private static readonly int tishTish = Animator.StringToHash("TishTish");

    

    [SerializeField]
    private AudioSource audios;
    [SerializeField]
    private AudioClip audioc;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<PlayerInventoryInteraction>())
        {
            audios.PlayOneShot(audioc);
           // StartCoroutine(monkyToyInteractable.PlayerGamingClip(0));
            Animate();
        }
    }

    public void Animate()
    {
        anim.SetTrigger(tishTish);
        pt.Play();
    }
}
