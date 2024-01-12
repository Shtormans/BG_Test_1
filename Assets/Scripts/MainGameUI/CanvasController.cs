using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private Canvas _gameOverCanvas;
    [SerializeField] private Canvas _pauseGameCanvas;
    [SerializeField] private Transform _leaderBoard;

    [SerializeField] private ScoreObserver _scoreObserver;
    [SerializeField] private PauseGameManager _pauseGameManager;
    [SerializeField] private LeaderboardController _leaderboardController;

    public event Action GameStarted;

    private void OnEnable()
    {
        FirebaseRepository.Instance.GetLeaderboard(UpdateScoreBoardCompleted);
    }

    private void UpdateScoreBoardCompleted(Result<List<UserWithScore>> usersResult)
    {
        if (usersResult.IsSuccess)
        {
            _leaderboardController.UpdateLeaderboardTable(usersResult.Value);
        }
    }

    public void StartGame()
    {
        GameStarted?.Invoke();

        _mainMenuCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
    }

    public void OpenLeaderboard()
    {
        _leaderBoard.gameObject.SetActive(true);
    }

    public void CloseLeaderboard()
    {
        _leaderBoard.gameObject.SetActive(false);
    }

    public void Revive()
    {
        _gameOverCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
    }

    public void StopGame()
    {
        _gameCanvas.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(true);

        _scoreObserver.AddToFinalScore();
    }

    public void PauseGame()
    {
        _pauseGameManager.Pause();

        _pauseGameCanvas.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        _pauseGameManager.Resume();

        _pauseGameCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void ExitFromAccount()
    {
        FirebaseRepository.Instance.SignOut();
        SceneController.ChangeSceneToMainMenu();
    }

    public void RestartGame()
    {
        SceneController.ChangeSceneToGame();
    }
}
