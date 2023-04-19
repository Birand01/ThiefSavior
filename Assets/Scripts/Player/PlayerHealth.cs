using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : HealthBase
{
    public static event Action OnPlayerRagdollHandler;
    public static event Action OnPlayerTakeDamageHandler;

    public delegate void OnPlayerDeadSoundHandler(string name, bool state);
    public static event OnPlayerDeadSoundHandler OnPlayerDeadSound;



    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        OnPlayerTakeDamageHandler?.Invoke();
    }

    protected override void CheckIfDead()
    {
        if (Health <= 0)
        {
            OnPlayerDeadSound?.Invoke("PlayerDeadSound", true);
            OnPlayerRagdollHandler?.Invoke();
        }
    }

  
}
