using UnityEngine;

public class RunState : State
{
    public RunState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        _animator.CrossFade("Fast Run (1)", 0.2f);

        _playerBehaviour.StartMoving();
    }
}
