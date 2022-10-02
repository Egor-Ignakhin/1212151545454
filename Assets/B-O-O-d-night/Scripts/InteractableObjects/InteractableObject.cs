using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual bool CanInteract()
    {
        throw new Exception();
    }
    public virtual void Interact()
    {
        throw new System.NotImplementedException();
    }
}