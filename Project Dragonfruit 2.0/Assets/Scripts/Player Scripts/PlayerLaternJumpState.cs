using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaternJumpState : PlayerBaseState
{
    public PlayerLaternJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState() { }
    public override void UpdateState() { }
    public override void ExitState() { }
    public override void CheckSwitchStates() { }
    public override void InitializeSubStates() { }
}
