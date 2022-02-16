using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{ 
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState() { }
    public override void UpdateState() { }
    public override void ExitState() { }
    public override void CheckSwitchStates() 
    {
        //When sprint is pressed, latern is off, envokes sprint state from factory
        if(_ctx.isSprintPressed)
        {
            SwitchState(_factory.SprintState());
        }
    }
    public override void InitializeSubStates() { }
}
