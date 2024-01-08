using UnityEngine;

public class SlideToLeftState : State
{
    public SlideToLeftState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        _playerBehaviour.SlideToLeft();
    }
}
