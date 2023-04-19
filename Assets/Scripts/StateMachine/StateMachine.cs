using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class StateMachine : MonoBehaviour
{
    private State currentState;
    private Dictionary<StateID,State> states;
    private void Awake()
    {
        states=new Dictionary<StateID,State>();
        AddState(new PatrolState(this));
        AddState(new ChaseState(this));
        AddState(new AttackState(this));
        AddState(new IdleState(this));
    }

    private void Update()
    { 
        StateID id = currentState.Decide();
        if(id!=StateID.NULL)
        {
            PerfomTransition(id);
        }
        currentState.Act();
    }

    private void AddState(State state)
    {
        if(states.ContainsKey(state.ID))
        {
            Debug.Log("Cannot add duplicate states each time " + state.ID.ToString());
            return;
        }
        if(states.Count==0)
        {
            currentState = state;
        }

        states.Add(state.ID, state);
    }

    private void PerfomTransition(StateID id)
    {
        currentState.OnLeaveState();  
        currentState=states[id];
        currentState.OnEnterState();
    }
}
