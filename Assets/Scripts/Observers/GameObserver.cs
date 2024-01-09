using UnityEngine;

public class GameObserver : MonoBehaviour
{
    [SerializeField] private CanvasController _canvasController;
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private PlayerStateMachine _stateMachine;
    [SerializeField] private PauseGameManager _pauseGameManager;

    private void OnEnable()
    {
        _canvasController.GameStarted += OnGameStarted;
        _playerBehaviour.Died += OnGameFinished;
    }

    private void OnDisable()
    {
        _canvasController.GameStarted -= OnGameStarted;
        _playerBehaviour.Died -= OnGameFinished;
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
}
