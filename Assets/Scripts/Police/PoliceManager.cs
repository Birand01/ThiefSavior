using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;


public class PoliceManager : BehaviourBase
{

    [SerializeField]
    protected float chaseSpeed;
    private PolicePistol policePistol;
 

    protected override void Awake()
    {

        policePistol = GetComponentInChildren<PolicePistol>();
        base.Awake();
      
    }
  
    protected override void Start()
    {
        objectToAttack = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public override void Move(Vector3 destination)
    {
        if (agent == null) return;
        agent.SetDestination(destination);      
    }
    public override void Attack()
    {
        if(agent!=null)
        {
            agent.isStopped = true;
            policePistol.Shoot();
        }
        
       
    }


    public override  void SearchObject()
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
    public override void Search()
    {
        agent.isStopped = false;
        isSearched = false;
        agent.speed = searchSpeed;
        Move(GetRandomPosition());

    }



    internal void Chase()
    {
        if (objectToAttack == null)
            return;
        agent.isStopped = false;
        agent.speed = chaseSpeed;
        agent.SetDestination(objectToAttack.position);

    }

   

   
}
