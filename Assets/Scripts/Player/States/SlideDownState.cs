using UnityEngine;

public class SlideDownState : State
{
    public SlideDownState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        Debug.Log(_playerBehaviour.IsSliding);

        if (_playerBehaviour.IsSliding)
        {
            return;
        }

        _animator.CrossFade(HashNameAnimator.SlideState, 0.1f);
        _playerBehaviour.Slide();
    }
}
