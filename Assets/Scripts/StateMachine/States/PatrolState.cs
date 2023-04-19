using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PatrolState : State
{
 
    private PoliceManager policeManager;
    private PoliceDistance distanceCheck;
    public PatrolState(StateMachine fsm)
    {
        id = StateID.PATROL;
        policeManager=fsm.GetComponent<PoliceManager>();
        distanceCheck = fsm.GetComponent<PoliceDistance>();
    }
    public override void Act()
    {
        //Patrol in unitsphere 
        policeManager.SearchObject();
    }

    public override StateID Decide()
    {
        //TODO: check if the police can get close to thief return stateID.Chase
        if (distanceCheck.ChaseRange())
        {
            return StateID.CHASE;
        }
       


        return StateID.NULL;
    }
    public override void OnLeaveState()
    {
        policeManager.Move(policeManager.transform.position);
    }
    public override void OnEnterState()
    {
        //policeManager.SearchThief();
    }
}
