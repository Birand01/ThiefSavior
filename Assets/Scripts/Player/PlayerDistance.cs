using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : DistanceBase
{
    public delegate void OnPlayerAttackEventHandler();
    public static event OnPlayerAttackEventHandler OnPlayerAttack;
   
    protected override void Start()
    {
        attackableObjectName = "Police";

    }
    private void Update()
    {
        if(AttackRange())
        {
            Debug.Log("PLAYER ATTACK");
            OnPlayerAttack?.Invoke();
        }
        
    }

  
   
}
