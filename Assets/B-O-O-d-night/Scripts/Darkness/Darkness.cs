using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SceneLoaderService))]
public class Darkness : MonoBehaviour
{
    private Animator anim;
    private static readonly int toLight = Animator.StringToHash("ToLight");
    private static readonly int toDark = Animator.StringToHash("ToDark");

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger(toLight);
    }

    public void ChangeScene()
    {
        GetComponent<Image>().enabled = true;
        anim.SetTrigger(toDark);
    }

    public void AnimEnd()
    {
        GetComponent<SceneLoaderService>().Load();
    }
}