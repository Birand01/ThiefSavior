using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteraction : InteractionBase
{
    public delegate void OnBulletDisableEventHandler();
    public static event OnBulletDisableEventHandler OnBulletDisable;
    internal float damage;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnBulletDisable?.Invoke();
        IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}
