using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreObserver : MonoBehaviour, IGamePauseSubscriber
{
    [SerializeField, Range(0, 10)] private int _scoreMultiplier = 1;
    [SerializeField, Range(0, 10)] public float _secondsToAddScore = 0.1f;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private PauseGameManager _pauseGameManager;

    private int _score;
    private Coroutine _changeScoreCoroutine;

    public int Score => _score;

    private void OnEnable()
    {
        _score = 0;

        _playerBehaviour.StartedMoving += StartChangingScore;
        _playerBehaviour.Died += StopChangingScore;
        _pauseGameManager.Paused += Pause;
        _pauseGameManager.Resumed += Resume;
    }

    private void OnDisable()
    {
        _playerBehaviour.StartedMoving -= StartChangingScore;
        _playerBehaviour.Died -= StopChangingScore;
        _pauseGameManager.Paused -= Pause;
        _pauseGameManager.Resumed -= Resume;
    }

    public void Pause()
    {
        if (_changeScoreCoroutine == null)
        {
            return;
        }

        StopCoroutine(_changeScoreCoroutine);
        _changeScoreCoroutine = null;
    }

    public void Resume()
    {
        StartChangingScore();
    }

    public void AddToFinalScore()
    {
        _finalScoreText.text = _score.ToString();
    }

    private IEnumerator ChangeScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(_secondsToAddScore);

            _score += _scoreMultiplier;
            _scoreText.text = _score.ToString();
        }
    }

    private void StartChangingScore()
    {
        if (_changeScoreCoroutine != null)
        {
            return;
        }

        _changeScoreCoroutine = StartCoroutine(ChangeScore());
    }

    private void StopChangingScore()
    {
        Pause();
    }
}
