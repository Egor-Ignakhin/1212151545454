using UnityEngine;

public class Monkey : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private ParticleSystem pt;

    private static readonly int tishTish = Animator.StringToHash("TishTish");

    [SerializeField] private MonkyToyInteractable monkyToyInteractable;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<PlayerInventoryInteraction>())
        {
            if (!monkyToyInteractable.WasInteracted) 
                return;

            StartCoroutine(monkyToyInteractable.PlayerGamingClip(0));
            Animate();
        }
    }

    public void Animate()
    {
        anim.SetTrigger(tishTish);
        pt.Play();
    }
}