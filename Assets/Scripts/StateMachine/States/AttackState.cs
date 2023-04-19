using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
   

    private PoliceManager policeManager;
    private PoliceDistance distanceCheck;
    private PoliceAnimationEvents policeAnimationEvents;
    private PoliceHealth policeHealth;
    public AttackState(StateMachine fsm)
    {
        id = StateID.ATTACK;
        policeManager = fsm.GetComponent<PoliceManager>();
        distanceCheck = fsm.GetComponent<PoliceDistance>();
        policeAnimationEvents = fsm.GetComponent<PoliceAnimationEvents>();
    }
    public override void Act()
    {
        Debug.Log("Attack");
        policeManager.LookAtTarget(policeManager.objectToAttack);
        policeManager.Attack();
    }

    public override StateID Decide()
    {
        if (policeManager.objectToAttack == null || distanceCheck.ChaseRange())
        {
            return StateID.CHASE;
        }
        else if (policeManager.objectToAttack.GetComponent<PlayerHealth>().Health <= 0)
        {
            return StateID.IDLE;
        }
        
       
        return StateID.NULL;
    }

    public override void OnEnterState()
    {
        policeAnimationEvents.AttackAnimationEvent(true);

    }

    public override void OnLeaveState()
    {
        policeAnimationEvents.AttackAnimationEvent(false);
    }


}
