using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
       : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
           
    }
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }
    public override void ExitState() { }
    public override void CheckSwitchStates()
    {
        //When sprint is pressed, latern is off, envokes sprint state from factory
        if (_ctx.isSprintPressed)
        {
            SwitchState(_factory.SprintState());
        }

        if(_ctx.isJumpPressed == true)
        {
            SwitchState(_factory.JumpState());
        }
    }
    public override void InitializeSubStates() { }
}

