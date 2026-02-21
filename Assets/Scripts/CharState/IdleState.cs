using UnityEngine;

public class IdleState : IPlayerState
{
        
    private UserControl p;
    Animator animator;
    public IdleState(UserControl player)
    {
        p = player;
        
    }
    public void Enter()
    {
        //if (p.IsMoving() == 0f)
        //{
        //    animator.SetFloat("IsWalk", 0f);
        //}
    }
    public void Update()
    {
            p.animator.SetFloat("IsWalk", 0f);
        if(p.IsMoving() > 0f) p.ChangeState(p.walkState);
    }
    public void Exit()
    {
        //if (p.IsMoving() >= 0.1f)
        //{
        //    animator.SetFloat("IsWalk", 0.2f);
        //}
    }
}
