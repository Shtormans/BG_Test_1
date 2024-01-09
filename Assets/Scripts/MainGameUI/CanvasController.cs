using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private Canvas _gameOverCanvas;
    [SerializeField] private Canvas _pauseGameCanvas;

    [SerializeField] private ScoreObserver _scoreObserver;
    [SerializeField] private PauseGameManager _pauseGameManager;

    public event Action GameStarted;

    public void StartGame()
    {
        GameStarted?.Invoke();

        _mainMenuCanvas.gameObject.SetActive(false);
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

    }

    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
