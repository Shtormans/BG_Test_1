using UnityEngine;

public class ReviveState : State
{
    public ReviveState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        _animator.CrossFade(HashNameAnimator.RunState, 0f);

        _playerBehaviour.StartMoving();
    }
}
