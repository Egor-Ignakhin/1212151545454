using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderService : MonoBehaviour
{
    [SerializeField] [ReadOnly] private List<string> sceneNames = new();
    [SerializeField] private string sceneName;
    [SerializeField] private LoadPoint loadPoint;

    private void Awake()
    {
        if (loadPoint == LoadPoint.Awake)
            LoadScene();
    }

    private void OnEnable()
    {
        if (loadPoint == LoadPoint.OnEnable)
            LoadScene();
    }

    private void Start()
    {
        if (loadPoint == LoadPoint.Start)
            LoadScene();
    }

    /// <summary>
    /// Custom load
    /// </summary>
    public void Load()
    {
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

#if UNITY_EDITOR

    private void OnValidate()
    {
        sceneNames.Clear();
        var sceneCount = SceneManager.sceneCountInBuildSettings;
        for (var i = 0; i < sceneCount; i++)
            sceneNames.Add(Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)));
    }
#endif
}