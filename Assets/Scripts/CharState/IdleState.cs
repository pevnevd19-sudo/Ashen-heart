using UnityEngine;

public class IdleState : IPlayerState
{

    private UserControl p;
    public IdleState(UserControl player)
    {
        p = player;

    }
    public void Enter()
    {
        p.playerState.ChangeState(p.idleState);
    }
    public void Update()
    {
        p.animator.SetFloat("Speed", p.IsMoving());
        p.playerState.ChangeState(p.idleState);
        if (p.IsMoving() < 0) p.playerState.ChangeState(p.walkState);
        Debug.Log("idle");
    }
    public void Exit()
    {
        p.animator.SetFloat("Speed", 0);

    }
}
