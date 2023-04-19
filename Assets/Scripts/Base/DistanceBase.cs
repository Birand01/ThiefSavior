using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class DistanceBase : MonoBehaviour
{
    protected NavMeshAgent agent;
    [SerializeField] protected float chaseRange, attackRange;
    protected Transform attackableObject;
    protected string attackableObjectName;
   
    protected virtual void Awake()
    {
      
        agent = GetComponent<NavMeshAgent>();
    }
    protected virtual void Start()
    {
        attackableObject = GameObject.FindGameObjectWithTag(attackableObjectName).transform;

    }
    internal bool ChaseRange()
    {
        if(ReturnDistanceToTarget()<chaseRange && ReturnDistanceToTarget()>attackRange)
        { return true; }
        return false;
    }
    public virtual bool AttackRange()
    {
        if(ReturnDistanceToTarget()<=attackRange)
        {
            return true;
        }

        return false;
    }
    internal bool PatrolRange()
    {
        if(ReturnDistanceToTarget()>chaseRange)
        {
            return true;
        }
        return false;
    }
    internal float ReturnDistanceToTarget()
    {
        float distanceToTarget = Vector3.Distance(attackableObject.position, transform.position);
        return distanceToTarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);

    }
}
