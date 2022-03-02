public class PlayerStateFactory
{
    PlayerStateMachine _context;
    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }
    public PlayerBaseState OffState()
    {
        return new PlayerOffState(_context, this);
    }
    public PlayerBaseState LanternWalkState()
    {
        return new PlayerLanternWalkState(_context, this);
    }
    public PlayerBaseState LanternState()
    {
        return new PlayerLanternState(_context, this);
    }

    public PlayerBaseState SprintState()
    {
        return new PlayerSprintState(_context, this);
    }
    public PlayerBaseState LanternSprintState()
    {
        return new PlayerLanternSprintState(_context, this);
    }
    public PlayerBaseState JumpState()
    {
        return new PlayerJumpState(_context, this);
    }
    public PlayerBaseState LanternJumpState()
    {
        return new PlayerLanternJumpState(_context, this);
    }
    public PlayerBaseState CrouchStateIdle()
    {
        return new PlayerCrouchingState(_context, this);
    }
    public PlayerBaseState CrouchStateWalking()
    {
        return new PlayerCrouchingStateWalking(_context, this);
    }
    public PlayerBaseState GroundState()
    {
        return new PlayerGroundState(_context, this);
    }




}
