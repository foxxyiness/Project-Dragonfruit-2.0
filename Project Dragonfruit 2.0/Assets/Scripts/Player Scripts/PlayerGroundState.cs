using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
       : base(currentContext, playerStateFactory)
    {
        _isRootState = true;
        InitializeSubStates();    
    }
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
        if(_ctx.isJumpPressed)
        {
            SwitchState(_factory.JumpState());
        }
    }
    public override void InitializeSubStates()
    {
        if(!_ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SetSubState(_factory.Idle());
        }
        else if (_ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SetSubState(_factory.OffState());
        }
        else if (_ctx.isMovementPressed && _ctx.isSprintPressed)
        {
            SetSubState(_factory.SprintState());
        }


    }
}

