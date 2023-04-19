using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRadius : AttackBase
{
    public delegate void OnPlayerAttackEventHandler(IDamageable target);
    public static event OnPlayerAttackEventHandler OnPoliceAttack;

    private void OnEnable()
    {
        PlayerInteraction.OnPoliceAddToList += TriggerEnterEvent;
    }
    private void OnDisable()
    {
        PlayerInteraction.OnPoliceAddToList -= TriggerEnterEvent;

    }

    public override void AttackBehaviour(IDamageable damageable)
    {
        Debug.Log("adasdsad");
        OnPoliceAttack?.Invoke(damageable);
    }
}
