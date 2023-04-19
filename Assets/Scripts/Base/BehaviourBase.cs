using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BehaviourBase : MonoBehaviour
{
    [SerializeField] protected float turnSpeed;
    [SerializeField] protected float patrolRadius, patrolWaitTime;
    [SerializeField] protected float searchSpeed;
    internal NavMeshAgent agent;
    internal Transform objectToAttack;
    protected string objectName;
    protected bool isSearched = false;
    private void OnEnable()
    {
        agent.enabled = true;
    }
    private void OnDisable()
    {
        agent.enabled = false;
    }

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    protected virtual void Start() { }
  
    public virtual void Attack() { }
    public virtual void SearchObject() 
    {
        if (!isSearched && agent.remainingDistance <= 0.1f || !agent.hasPath && !isSearched)
        {
            Vector3 agentTarget = new Vector3(agent.destination.x, transform.position.y, agent.destination.z);
            agent.enabled = false;
            transform.position = agentTarget;
            agent.enabled = true;
            Invoke(nameof(Search), patrolWaitTime);
            isSearched = true;
        }
    }
    public virtual void Search()
    {
        agent.isStopped = false;
        isSearched = false;
        agent.speed = searchSpeed;
        Move(GetRandomPosition());

    }

    public virtual void Move(Vector3  destination)
    {
        if (agent == null) return;
        agent.SetDestination(destination);
    }
    
   
   
    public virtual void LookAtTarget(Transform target)
    {
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = turnSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 10.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    protected virtual Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1);
        return hit.position;

    }
}
