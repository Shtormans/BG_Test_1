using UnityEngine;

public class JumpState : State
{
    public JumpState(PlayerBehaviour player, Animator animator)
        : base(player, animator)
    {

    }

    public override void Use()
    {
        _playerBehaviour.Jump();
    }
}
