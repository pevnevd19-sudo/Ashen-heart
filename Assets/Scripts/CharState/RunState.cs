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
    }
    public void Update()
    {
        p.animator.SetFloat("IsRun", p.IsMoving());
        if (p.IsMoving() <= 5f) p.ChangeState(p.walkState);
    }
    public void Exit()
    {

    }
}

