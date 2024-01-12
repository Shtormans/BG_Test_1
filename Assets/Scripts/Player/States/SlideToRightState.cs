using UnityEngine;

public class SlideToRightState : State
{
    public SlideToRightState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        _playerBehaviour.SlideToRight();
    }
}
