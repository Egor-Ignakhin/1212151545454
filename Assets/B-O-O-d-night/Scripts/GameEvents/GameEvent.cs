using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    protected List<GameEventTrigger> triggers = new ();

    public virtual void Activate()
    {
    }
}