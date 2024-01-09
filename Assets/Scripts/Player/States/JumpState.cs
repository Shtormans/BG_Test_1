using UnityEngine;

public class JumpState : State
{
    public JumpState(PlayerBehaviour player, Animator animator)
        : base(player, animator)
    {

    }

    public override void Use()
    {
        if (_playerBehaviour.IsJumping)
        {
            return;
        }

        _animator.CrossFade(HashNameAnimator.JumpState, 0.2f);
        _playerBehaviour.Jump();
    }
}
