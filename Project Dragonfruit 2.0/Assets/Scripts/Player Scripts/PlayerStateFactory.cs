public class PlayerStateFactory
{
    PlayerStateMachine _context;
    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerBaseState Idle()
    {
        return new PlayerIdleState();
    }
    public PlayerBaseState OffState()
    {
        return new PlayerOffState();
    }
    public PlayerBaseState LaternState()
    {
        return new PlayerLaternState();
    }

    public PlayerBaseState SprintState()
    {
        return new PlayerSprintState();
    }
    public PlayerBaseState LaternSprintState()
    {
        return new PlayerLaternSprintState();
    }
    public PlayerBaseState JumpState()
    {
        return new PlayerJumpState();
    }
    public PlayerBaseState LanternJumpState()
    {
        return new PlayerLaternJumpState();
    }
    public PlayerBaseState CrouchState()
    {
        return new PlayerCrouchingState();
    }




}
