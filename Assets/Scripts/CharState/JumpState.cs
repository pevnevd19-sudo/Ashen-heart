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
    }

    public void Update()
    {
        if (p.IsGrounded())
        {
            if (p.IsMoving() > 0.1f)
                p.ChangeState(p.walkState);
            else
                p.ChangeState(p.idleState);
        }
    }

    public void Exit()
    {
        p.animator.SetBool("IsJump", false);
    }

}
