using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchingStateWalking : PlayerBaseState
{
    public PlayerCrouchingStateWalking(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
       : base(currentContext, playerStateFactory)
    {
       
    }
    public override void EnterState()
    {
        _ctx.sprintSpeed = 0.75f;
        _ctx.Animator.SetBool("isWalking", true);
        _ctx.Animator.SetBool("isIdle", false);
        _ctx.Animator.SetBool("isCrouching", true);
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState() 
    {
        _ctx.sprintSpeed = 1.0f;
        _ctx.Animator.SetBool("isCrouching", false);
    }
    public override void CheckSwitchStates()
    {
        //When sprint is pressed, latern is off, envokes sprint state from factory
        if (!_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateIdle());
        }
     /*   else if (_ctx.isMovementPressed && _ctx.isSprintPressed)
        {
            SwitchState(_factory.SprintState());
        }*/
        else if (!_ctx.isMovementPressed && !_ctx.isCrouchedPressed)
        {
            SwitchState(_factory.Idle());
        }
        else if (_ctx.isMovementPressed && !_ctx.isCrouchedPressed)
        {
            SwitchState(_factory.OffState());
        }
    }
    public override void InitializeSubStates()
    {
      

    }
}
