using UnityEngine;

public class JumpState : IPlayerState
{
    private UserControl p;
    Animator animator;
    public JumpState(UserControl player)
    {
        p = player;
    }
    public void Enter()
    {
        p.animator.SetBool("IsJump", true);
        p.playerState.ChangeState(p.jumpState);
    }

    public void Update()
    {
        p.animator.SetBool("IsJump", !p.IsGrounded());
        p.playerState.ChangeState(p.jumpState);
    }

    public void Exit()
    {
        p.animator.SetBool("IsJump", false);
    }

}
