using UnityEditor;
using UnityEngine;

namespace DiceGame.Scripts.Editor
{
    public static class StdSceneFoldersCreator
    {
        private static readonly string[] folders =
            { "Common", "Environment", "Scene", "Camera", "Characters", "UI", "Other" };
#if UNITY_EDITOR
        [MenuItem("Tools/ Create Standard Folders")]
        public static void CreateStdFolders()
        {
            foreach (var f in folders)
            {
                var go = GameObject.Find(f);
                if (go) continue;
                Debug.Log($"Create STD Folder ===> {f}");
                go = new GameObject(f);
            }
        }
#endif
    }
}