using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    private PoliceManager policeManager;
    private PoliceDistance distanceCheck;
    private PoliceAnimationEvents policeAnimationEvents;
    public ChaseState(StateMachine fsm)
    {
        id = StateID.CHASE;
        policeManager = fsm.GetComponent<PoliceManager>();
        distanceCheck = fsm.GetComponent<PoliceDistance>();
        policeAnimationEvents = fsm.GetComponent<PoliceAnimationEvents>();
    }
    public override void Act()
    {
        if (policeManager.objectToAttack == null) return;
        policeManager.Chase();
    }

    public override StateID Decide()
    {
        if (policeManager.objectToAttack != null && distanceCheck.AttackRange())
        {
            return StateID.ATTACK;
        }
        else if (policeManager.objectToAttack != null && distanceCheck.PatrolRange())
        {
            return StateID.PATROL;
        }

        return StateID.NULL;
    }
    public override void OnEnterState()
    {
        policeAnimationEvents.ChaseAnimationEvent(true);
    }
    public override void OnLeaveState()
    {
        policeAnimationEvents.ChaseAnimationEvent(false);
    }
}
