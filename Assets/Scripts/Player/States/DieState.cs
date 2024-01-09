using UnityEngine;

public class DieState : State
{
    public DieState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        _animator.CrossFade(HashNameAnimator.DieState, 0.2f);
    }
}
