using UnityEngine;

public class GameObserver : MonoBehaviour
{
    [SerializeField] private CanvasController _canvasController;
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private ScoreObserver _scoreObserver;
    [SerializeField] private PlayerStateMachine _stateMachine;
    [SerializeField] private PauseGameManager _pauseGameManager;
    [SerializeField] private WorldMonitor _worldMonitor;
    [SerializeField] private ReviveAdController _reviveAddController;
    [SerializeField] private PlayerContainer _playerContainer;

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
        int score = _scoreObserver.Score;
        int maxScore = _playerContainer.MaxScore;

        if (score > maxScore)
        {
            _playerContainer.SetMaxScore(score);
            FirebaseRepository.Instance.SaveScore(score);
        }

        _canvasController.StopGame();
    }

    public void RevivePlayer()
    {
        _canvasController.Revive();
        _worldMonitor.ChangeFirstChunksToSafe();
        _playerBehaviour.Revive();
    }
}
