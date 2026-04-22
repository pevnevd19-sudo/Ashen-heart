using UnityEngine;

public class FallState : IPlayerState
{
    private UserControl p;

    public FallState (UserControl player)
    {
        p = player;
    }

    public void Enter()
    {
        p.animator.SetBool("IsFall", true);
        p.playerState.ChangeState(p.fallState);
    }
    public void Update()
    {
        p.animator.SetBool("IsFall", p.isFall());
        p.playerState.ChangeState(p.fallState);
        
    }

    public void Exit()
    {
        p.animator.SetBool("IsFall", false);
    }

    
}
