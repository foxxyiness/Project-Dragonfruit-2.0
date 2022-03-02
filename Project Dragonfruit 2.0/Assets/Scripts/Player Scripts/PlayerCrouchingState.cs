using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchingState : PlayerBaseState
{
    public PlayerCrouchingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        _ctx.lightOn = false;
        _ctx.latern.SetActive(false);
        _ctx.Animator.SetBool("isIdle", true);
        _ctx.Animator.SetBool("isWalking", false);
        _ctx.Animator.SetBool("isCrouching", true);

    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        _ctx.Animator.SetBool("isCrouching", false);
    }
    public override void CheckSwitchStates()
    {
        if (_ctx.isMovementPressed && !_ctx.isCrouchedPressed)
        {
            SwitchState(_factory.OffState());
        }
        else if(!_ctx.isMovementPressed && !_ctx.isCrouchedPressed)
        {
            SwitchState(_factory.Idle());
        }
        else if(_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateWalking());
        }


    }
    public override void InitializeSubStates() { }
}

