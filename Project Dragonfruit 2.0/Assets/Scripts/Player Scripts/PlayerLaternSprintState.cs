using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLanternSprintState : PlayerBaseState
{
    public PlayerLanternSprintState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.sprintSpeed = 1.5f;
        _ctx.Animator.SetBool("LanternOn", true);
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
        _ctx.Animator.SetBool("LanternOn", false);
    }
    public override void CheckSwitchStates()
    {
        if (!_ctx.isMovementPressed && !_ctx.isSprintPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternState());
        }
        else if (_ctx.isMovementPressed && !_ctx.isSprintPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternWalkState());
        }
        else if (_ctx.isMovementPressed && !_ctx.isLightOn)
        {
            SwitchState(_factory.SprintState());
        }
        else if(_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateWalking());
        }
        else if(!_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateIdle());
        }
    }
    public override void InitializeSubStates() { }
}
