using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
  
    internal List<IDamageable> damageables;
    protected float minDistanceToAttack;
    protected float attackDelay;
    private Coroutine attackCoroutine;


    private void Awake()
    {

        damageables = new List<IDamageable>();

    }


    protected virtual void TriggerEnterEvent(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageables.Add(damageable);
            Debug.Log(damageable.GetTransform().name);
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(Attack());
            }
        }


    }
    protected virtual void DeadEnemyEvent(IDamageable damageable)
    {
        if (damageable != null)
        {

            damageables.Remove(damageable);
            if (damageables.Count == 0)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }
   
    protected virtual IEnumerator Attack()
    {
        WaitForSeconds wait = new WaitForSeconds(attackDelay);
        IDamageable closestDamageable = null;
        float closestDistance = minDistanceToAttack;
        while (damageables.Count > 0)
        {
            for (int i = 0; i < damageables.Count; i++)
            {
                Transform damageableTransform = damageables[i].GetTransform();
                float distanceToTarget = Vector3.Distance(transform.position, damageableTransform.position);
                if (distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    closestDamageable = damageables[i];

                }
            }

            if (closestDamageable != null)
            {
                AttackBehaviour(closestDamageable);
               // ATTACK BEHAVIOR WILL BE OBSERVED
            }

            closestDamageable = null;
            closestDistance = minDistanceToAttack;
            yield return wait;
            damageables.RemoveAll(DisabledDamageables);

        }
        attackCoroutine = null;
    }
    private bool DisabledDamageables(IDamageable damageable)
    {
        return damageable != null && !damageable.GetTransform().gameObject.activeSelf;
    }
    public abstract void AttackBehaviour(IDamageable damageable);
}
