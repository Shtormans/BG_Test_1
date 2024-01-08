using UnityEngine;

public class DieState : State
{
    public DieState(PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
