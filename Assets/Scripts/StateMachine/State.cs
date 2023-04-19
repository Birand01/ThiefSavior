using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateID
{
    NULL=0,
    PATROL,CHASE,ATTACK,IDLE,DEAD
}
public abstract class State
{
    protected StateID id = StateID.NULL;
    public StateID ID
    {
        get { return id; }
    }
    public abstract void Act();
    public abstract StateID Decide();
    public virtual void OnEnterState() { }
    public virtual void OnLeaveState() { }
}
