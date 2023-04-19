using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private PoliceAnimationEvents policeAnimationEvents;
    private PoliceManager policeManager;
    public IdleState(StateMachine fsm)
    {
        id = StateID.IDLE;
        policeAnimationEvents = fsm.GetComponent<PoliceAnimationEvents>();
        policeManager = fsm.GetComponent<PoliceManager>();
    }
    public override void Act()
    {
        //policeManager.AgentState();
        //policeAnimationEvents.WinAnimation();
    }

    public override StateID Decide()
    {
        return StateID.NULL;
    }

    public override void OnEnterState()
    {

        policeAnimationEvents.WinAnimation();
    }
}
