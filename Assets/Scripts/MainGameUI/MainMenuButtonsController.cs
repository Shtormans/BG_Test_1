using UnityEngine;

public class MainMenuButtonsController : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private PlayerStateMachine _stateMachine;

    public void StartGame()
    {
        _stateMachine.SetState<RunState>();

        _mainMenuCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void ExitFromAccount()
    {

    }
}
