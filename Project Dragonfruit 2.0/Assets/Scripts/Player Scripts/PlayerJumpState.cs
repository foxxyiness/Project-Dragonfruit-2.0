using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        Jump();
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState() { }
    public override void CheckSwitchStates()
    {
        if(_ctx.isGrounded)
        {
            SwitchState(_factory.GroundState());
            _ctx.isJumpPressed = false;
        }
    }
    public override void InitializeSubStates() { }

    void Jump()
    {
        if (_ctx.groundCheck == true)
        {
            _ctx.rb.AddForce(Vector2.up * _ctx.rb.velocity.y * _ctx.powerJump, ForceMode2D.Impulse);
            _ctx.isGrounded = false;
        }
    }


}
