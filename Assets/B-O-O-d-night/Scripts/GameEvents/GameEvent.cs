using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
   [SerializeField] protected List<GameEventTrigger> triggers = new ();

    public virtual void Activate()
    {
        throw new Exception();
    }
}