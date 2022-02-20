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
    }
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }
    public override void ExitState() { }
    public override void CheckSwitchStates() 
    {
        if (!_ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SwitchState(_factory.Idle());
        } else if (_ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SwitchState(_factory.OffState());
        } 
    }
    public override void InitializeSubStates() { }
}
