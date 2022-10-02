using System;
using UnityEngine;

public class MomeWatchingController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private ProgressChecker progressChecker;
    private bool isInsideRoom;

    private void Awake()
    {
        TenSecondsLoop.OnMomeEntered += TenSecondsLoopOnOnMomeEntered;
        TenSecondsLoop.OnMomeExit += TenSecondsLoopOnOnMomeExit;
    }

    private void TenSecondsLoopOnOnMomeEntered()
    {
        isInsideRoom = true;
    }
    private void TenSecondsLoopOnOnMomeExit()
    {
        isInsideRoom = false;
    }

    private void Update()
    {
        if(!isInsideRoom)
        return;
        
        if (!playerController.IsInsideWardrobe)
        {
            PlayerController.IsCaught = true;
            progressChecker.MoveToBadScreen();
        }
    }

    private void OnDestroy()
    {
        TenSecondsLoop.OnMomeEntered -= TenSecondsLoopOnOnMomeEntered;
        TenSecondsLoop.OnMomeExit -= TenSecondsLoopOnOnMomeExit;
    }
}