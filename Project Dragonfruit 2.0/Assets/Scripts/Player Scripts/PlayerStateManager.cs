using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    PlayerOffState OffState = new PlayerOffState();
    PlayerLaternState LaternState = new PlayerLaternState();
    PlayerCrouchingState CrouchingState = new PlayerCrouchingState();
    void Start()
    {
        currentState = OffState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
