using UnityEngine;

public class RunState : IPlayerState
{
    private UserControl p;

    public RunState(UserControl player)
    {
        p = player;
    }
    public void Enter()
    {
        p.animator.SetFloat("Speed", p.IsMoving());
        p.playerState.ChangeState(p.runState);
    }
    public void Update()
    {
        p.animator.SetFloat("Speed", p.IsMoving());
        p.playerState.ChangeState(p.runState);
        if (p.IsMoving() < 5f)
        {
            p.playerState.ChangeState(p.walkState);
            p.animator.SetFloat("Speed", 0);
        }
        Debug.Log("Run");
    }
    public void Exit()
    {
        p.animator.SetFloat("Speed", p.IsMoving());
    }
}

