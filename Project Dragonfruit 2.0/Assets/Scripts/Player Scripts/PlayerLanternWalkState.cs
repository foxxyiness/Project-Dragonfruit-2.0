using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLanternWalkState : PlayerBaseState
{
    public PlayerLanternWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
      : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.sprintSpeed = 1.0f;
        _ctx.Animator.SetBool("LanternOn", true);
        _ctx.Animator.SetBool("isWalking", true);

    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        _ctx.Animator.SetBool("LanternOn", false);
        _ctx.Animator.SetBool("isWalking", false);
    }
    public override void CheckSwitchStates()
    {
        if (!_ctx.isMovementPressed && !_ctx.isLightOn)
        {
            SwitchState(_factory.Idle());
        }
        else if (_ctx.isMovementPressed && _ctx.isSprintPressed)
        {
            SwitchState(_factory.SprintState());
        }
        else if(_ctx.isMovementPressed && !_ctx.isLightOn)
        {
            SwitchState(_factory.OffState());
        }
        else if (_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateWalking());
        }
        else if (!_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateIdle());
        }
        else if(!_ctx.isMovementPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternState());
        }
        else if (_ctx.isSprintPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternSprintState());
        }

    }
    public override void InitializeSubStates() { }
}
