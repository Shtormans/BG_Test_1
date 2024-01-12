using UnityEngine;

public class RunState : State
{
    public RunState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        _animator.CrossFade(HashNameAnimator.RunState, 0.1f);

        _playerBehaviour.StartRunning();
    }
}
