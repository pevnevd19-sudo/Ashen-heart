using UnityEngine;

public class CrouchWalkState : IPlayerState
{
    private UserControl p;
    public CrouchWalkState(UserControl player )
    {
        p = player;
    }
    public void Enter()
    {
        p.animator.SetBool("CrouchWalk", true);

    }

    public void Exit()
    {
        p.animator.SetBool("CrouchWalk", false);
    }

    public void Update()
    {
        p.animator.SetBool("CrouchWalk", true);
        if (UserInput.Vertical > -0.3) Exit();
    }
}
