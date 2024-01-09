using UnityEngine;

public class StartGameState : State
{
    private PlayerStateMachine _stateMachine;

    public StartGameState(PlayerStateMachine stateMachine, PlayerBehaviour player, Animator animator) 
        : base(player, animator)
    {
        _stateMachine = stateMachine;
    }

    public override void Use()
    {
        _playerBehaviour.transform.Rotate(0, 180, 0);

        _stateMachine.SetState<RunState>();
    }
}
