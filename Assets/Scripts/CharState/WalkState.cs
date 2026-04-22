using UnityEngine;

public class WalkState : IPlayerState
{
    private UserControl p;

    public WalkState(UserControl player)
    {
        p = player;
    }
    public void Enter()
    {
        p.animator.SetFloat("Speed", p.IsMoving());
        p.playerState.ChangeState(p.walkState);
    }
    public void Update()
    {
        p.animator.SetFloat("Speed", p.IsMoving());
        p.playerState.ChangeState(p.walkState);
        if (p.IsMoving() <= 0f)
        {
            p.animator.SetFloat("Speed", 0);
            p.playerState.ChangeState(p.idleState);
        }  
        Debug.Log("Walk");
    }
    public void Exit()
    {
        p.animator.SetFloat("Speed", 0);
    }
}
