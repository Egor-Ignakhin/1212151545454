using System.Collections;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private IEnumerator Start()
    {
        while (true)
        {
            print("new cycle");
            yield return new WaitForSeconds(10f);
        }
    }
}