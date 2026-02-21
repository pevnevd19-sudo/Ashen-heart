using UnityEngine;

public class WalkState : IPlayerState
{
    private UserControl p;
    private Animator animator;

    public WalkState(UserControl player)
    {
        p = player;
    }
    public void Enter()
    {
        //if (p.IsMoving() >= 0.2f)
        //{
        //    animator.SetFloat("IsWalk",0.2f);
        //}
    }
    public void Update()
    {
        p.animator.SetFloat("IsWalk",p.IsMoving());
        if (p.IsMoving() <= 0) p.ChangeState(p.idleState);
    }
    public void Exit()
    {
        //if (p.IsMoving() <= 0.1f)
        //{
        //    animator.SetFloat("IsWalk", 0f);
        //}
    }
}
