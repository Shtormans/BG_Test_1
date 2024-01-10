using UnityEngine;

public class GameObserver : MonoBehaviour
{
    [SerializeField] private CanvasController _canvasController;
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private PlayerStateMachine _stateMachine;
    [SerializeField] private PauseGameManager _pauseGameManager;
    [SerializeField] private WorldMonitor _worldMonitor;
    [SerializeField] private ReviveAddController _reviveAddController;

    private void OnEnable()
    {
        _canvasController.GameStarted += OnGameStarted;
        _playerBehaviour.Died += OnGameFinished;
        _reviveAddController.AdSuccessfullyEnded += RevivePlayer;
    }

    private void OnDisable()
    {
        _canvasController.GameStarted -= OnGameStarted;
        _playerBehaviour.Died -= OnGameFinished;
        _reviveAddController.AdSuccessfullyEnded -= RevivePlayer;
    }

    public void OnGameStarted()
    {
        _pauseGameManager.Resume();
        _playerBehaviour.StartMoving();
        _stateMachine.SetState<StartGameState>();
    }

    public void OnGameFinished()
    {
        _canvasController.StopGame();
    }

    public void RevivePlayer()
    {
        _canvasController.Revive();
        _worldMonitor.ChangeFirstChunksToSafe();
        _playerBehaviour.Revive();
    }
}
