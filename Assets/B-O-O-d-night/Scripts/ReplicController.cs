using UnityEngine;

public class ReplicController : MonoBehaviour
{
    [SerializeField] private int CurrentStage;
    [SerializeField] private GameObject[] GOs;

    [SerializeField] private Darkness darkness;

    private void Start()
    {
        for (var i = 0; i < GOs.Length; i++) GOs[i].SetActive(false);
        GOs[CurrentStage].SetActive(true);
    }

    public void NextStage()
    {
        if (GOs.Length > CurrentStage + 1)
        {
            CurrentStage++;
            GOs[CurrentStage - 1].SetActive(false);
            GOs[CurrentStage].SetActive(true);
        }
        else
            darkness.ChangeScene();
    }
}