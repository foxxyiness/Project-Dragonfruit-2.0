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
        _ctx.Animator.speed = 1.0f;
    }
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }
    public override void ExitState() { }
    public override void CheckSwitchStates()
    {
        //When sprint is pressed, latern is off, envokes sprint state from factory
        if(_ctx.isJumpPressed && !_ctx.isLightOn)
        {
            SwitchState(_factory.JumpState());
        }
        if(_ctx.isJumpPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternJumpState());
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
        else if(_ctx.isMovementPressed && _ctx.isLightOn)
        {
            SetSubState(_factory.LanternWalkState());
        }
        else if(!_ctx.isMovementPressed && _ctx.isLightOn)
        {
            SetSubState(_factory.LanternState());
        }
        else if(_ctx.isSprintPressed && _ctx.isLightOn && _ctx.isMovementPressed)
        {
            SetSubState(_factory.LanternSprintState());
        }


    }
}

