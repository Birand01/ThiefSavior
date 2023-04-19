using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInteraction : InteractionBase
{
    public delegate void OnGoalReachEventHandler();
    public static event OnGoalReachEventHandler OnGoalReach;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        collider.isTrigger = false;
        OnGoalReach?.Invoke();
    }
}
