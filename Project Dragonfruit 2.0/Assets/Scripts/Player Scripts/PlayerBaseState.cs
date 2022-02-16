using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) 
    {
        _ctx = currentContext;
        _factory = playerStateFactory;
    }
    protected PlayerStateMachine _ctx;
    protected PlayerStateFactory _factory;
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubStates();
  
    void UpdateStates() { }
    protected void SwitchState(PlayerBaseState newState) 
    {
        //exit current state
        ExitState();
        //enters new state
        newState.EnterState();
        //switch current state of context
        _ctx.CurrentState = newState;
    }
    protected void SetSuperState() { }
    protected void SetSubState() { }



}
