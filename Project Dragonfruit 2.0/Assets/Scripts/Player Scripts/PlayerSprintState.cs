using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    public PlayerSprintState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        _ctx.sprintSpeed = 1.5f;
        _ctx.Animator.SetBool("isIdle", false);
        _ctx.Animator.SetBool("isSprinting", true);
    }
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }
    public override void ExitState() 
    {
        _ctx.sprintSpeed = 1.0f;
        _ctx.Animator.SetBool("isSprinting", false);
    }
    public override void CheckSwitchStates() 
    {
        if (!_ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SwitchState(_factory.Idle());
        } 
        else if (_ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SwitchState(_factory.OffState());
        } 
        else if (_ctx.isMovementPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternSprintState());
        }
    }
    public override void InitializeSubStates() { }
}
