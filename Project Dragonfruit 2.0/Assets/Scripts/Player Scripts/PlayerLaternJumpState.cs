using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLanternJumpState : PlayerBaseState
{
    public PlayerLanternJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        _isRootState = true;
        InitializeSubStates();
    }
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
        if (_ctx.isGrounded)
        {

            // _ctx.StartCoroutine(JumpReverse());
            SwitchState(_factory.GroundState());
            //_ctx.isJumpPressed = false;
        }
    }
    public override void InitializeSubStates()
    {
        if ( _ctx.isLightOn && !_ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SetSubState(_factory.LanternState());
        }
        else if ( _ctx.isLightOn && _ctx.isMovementPressed && !_ctx.isSprintPressed)
        {
            SetSubState(_factory.LanternWalkState());
        }
        else if ( _ctx.isLightOn && _ctx.isMovementPressed && _ctx.isSprintPressed)
        {
            SetSubState(_factory.LanternSprintState());
        }
    }

    void Jump()
    {
        Debug.Log("JUMP");
        _ctx.rb.AddForce(Vector2.up * _ctx.powerJump, ForceMode2D.Impulse);
        _ctx.isGrounded = false;
        _ctx.Animator.SetBool("LanternOn", true);
        _ctx.Animator.SetBool("isJumping", true);
    }
    IEnumerator JumpReverse()
    {
        yield return new WaitForSeconds(1);
    }

}
