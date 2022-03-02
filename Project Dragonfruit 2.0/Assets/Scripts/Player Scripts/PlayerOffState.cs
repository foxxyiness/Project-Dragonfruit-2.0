using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffState : PlayerBaseState
{
    public PlayerOffState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        _ctx.sprintSpeed = 1.0f;
        _ctx.Animator.SetBool("isWalking", true);
        _ctx.Animator.SetBool("isIdle", false);
        
    }
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }
    public override void ExitState() 
    {
    }
    public override void CheckSwitchStates() 
    {
        if (!_ctx.isMovementPressed)
        {
            SwitchState(_factory.Idle());
        }
        else if(_ctx.isMovementPressed && _ctx.isSprintPressed)
        {
            SwitchState(_factory.SprintState());
        }

    }
    public override void InitializeSubStates() { }
}
