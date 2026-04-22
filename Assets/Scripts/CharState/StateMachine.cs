using UnityEngine;

public class StateMachine
{
    public IPlayerState currentState { get; set; }
    public void ChangeState(IPlayerState playerState)
    {
        if (currentState == playerState) return;

        currentState?.Exit();
        currentState = playerState;
        currentState.Enter();
    }
    public void Update()
    {
        currentState?.Update();
    }

}
