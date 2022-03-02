using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{ 
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        
        _ctx.Animator.SetBool("isIdle", true);
        _ctx.Animator.SetBool("isWalking", false);
        

    }
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }
    public override void ExitState() { }
    public override void CheckSwitchStates() 
    {
        if (_ctx.isMovementPressed)
        {
            SwitchState(_factory.OffState());
        } else if (_ctx.isMovementPressed && _ctx.isSprintPressed)
        {
            SwitchState(_factory.SprintState());
        }
        else if(!_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateIdle());
        }
        else if(_ctx.isMovementPressed && _ctx.isCrouchedPressed)
        {
            SwitchState(_factory.CrouchStateWalking());
        }
        else if(!_ctx.isMovementPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternState());
        }
        else if(_ctx.isMovementPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternWalkState());
        }
        else if(_ctx.isSprintPressed && _ctx.isLightOn)
        {
            SwitchState(_factory.LanternSprintState());
        }
        

    }
    public override void InitializeSubStates() { }
}
