using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;

    private Dictionary<Type, State> _states;

    private void Awake()
    {
        _states = new Dictionary<Type, State>()
        {
            { typeof(StartGameState), new StartGameState(this, _player, _player.Animator) },
            { typeof(SlideToLeftState), new SlideToLeftState(_player, _player.Animator) },
            { typeof(SlideToRightState), new SlideToRightState(_player, _player.Animator) },
            { typeof(SlideDownState), new SlideDownState(_player, _player.Animator) },
            { typeof(JumpState), new JumpState(_player, _player.Animator) },
            { typeof(RunState), new RunState(_player, _player.Animator) },
            { typeof(DieState), new DieState(_player, _player.Animator) }
        };
    }

    public void SetState<TState>()
    {
        _states[typeof(TState)].Use();
    }
}
