using UnityEngine;

public class SlideDownState : State
{
    public SlideDownState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        if (_playerBehaviour.IsSliding)
        {
            return;
        }

        _animator.CrossFade(HashNameAnimator.SlideState, 0.1f);
        _playerBehaviour.StartSliding();
    }
}
