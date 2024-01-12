using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine _stateMachine;
    private IInputHandler _inputHandler;

    private void Awake()
    {
#if UNITY_EDITOR
        SetInputHandler(new KeyboardInputHandler(_stateMachine));
#elif UNITY_ANDROID
        SetInputHandler(new AndroidInputHandler(_stateMachine));
#endif
    }

    private void Update()
    {
        _inputHandler.Handle();
    }

    private void SetInputHandler(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }
}
