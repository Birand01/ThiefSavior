using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : InteractionBase
{
    public delegate void OnPlayerInteractionEvent(Collider collider);
    public static event OnPlayerInteractionEvent OnPoliceAddToList;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        Debug.Log(collider.name);
        OnPoliceAddToList?.Invoke(collider);
    }

    
}
