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
    }

    public void Exit()
    {
        p.animator.SetBool("CrouchIdle", false);

    }


    public void Update()
    {
        p.animator.SetBool("CrouchIdle", true);
        if (UserInput.Vertical > -0.3) Exit();

    }
}
