using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLanternState : PlayerBaseState
{
    public PlayerLanternState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
          : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.Animator.SetBool("LanternOn", true);
        _ctx.Animator.SetBool("isIdle", true);
        _ctx.Animator.SetBool("isWalking", false);


    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        _ctx.Animator.SetBool("LanternOn", false);
        _ctx.Animator.SetBool("isIdle", false);
    }
    public override void CheckSwitchStates()
    {
        if (_ctx.isMovementPressed && !_ctx.isLightOn)
        {
            SwitchState(_factory.OffState());
        }
        else if (_ctx.isMovementPressed && _ctx.isSprintPressed)
        {
            SwitchState(_factory.SprintState());
        }
        else if (!_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateIdle());
        }
        else if (_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateWalking());
        }
        else if (_ctx.isLightOn && _ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SwitchState(_factory.LanternWalkState());
        }
        else if(_ctx.isLightOn && _ctx.isSprintPressed && _ctx.isMovementPressed)
        {
            SwitchState(_factory.LanternSprintState());
        }
        else if (!_ctx.isMovementPressed && !_ctx.isLightOn)
        {
            SwitchState(_factory.Idle());
        }
        


    }
    public override void InitializeSubStates() { }
}
