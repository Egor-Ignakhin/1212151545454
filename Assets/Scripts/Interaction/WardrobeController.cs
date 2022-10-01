using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Transform playerPointInside;

    public void MovePlayerInside()
    {
        playerController.MoveInsideWardobe(playerPointInside.position);
    }
}