using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Darkness : MonoBehaviour
{
    [SerializeField]
    private int NewSceneName;
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("ToLight");
    }
    public void ChangeScene()
    {
        anim.SetTrigger("ToDark");
    }

    public void AnimEnd()
    {
        SceneManager.LoadScene(NewSceneName);
    }
}
