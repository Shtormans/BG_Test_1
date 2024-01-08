using UnityEngine;

public abstract class State
{
    protected PlayerBehaviour _playerBehaviour;
    protected Animator _animator;

    public State(PlayerBehaviour player, Animator animator)
    {
        _playerBehaviour = player;
        _animator = animator;
    }

    public abstract void Use();
}
