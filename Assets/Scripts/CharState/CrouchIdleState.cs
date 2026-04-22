using UnityEngine;

public class CrouchIdleState : IPlayerState
{
    private UserControl p;
    public CrouchIdleState(UserControl player)
    {
        p = player;
    }
    public void Enter()
    {
        p.animator.SetBool("CrouchIdle", true);
        p.playerState.ChangeState(p.idleState);
    }

    public void Exit()
    {
        p.animator.SetBool("CrouchIdle", false);
        p.playerState.ChangeState(p.idleState);
    }

    public void Update()
    {
        p.animator.SetBool("CrouchIdle", true);
        if (UserInput.Vertical >= 0) Exit();
        Debug.Log("crouchIdle");

    }
}
