using UnityEngine;

public class KeyboardInputHandler : IInputHandler
{
    private PlayerStateMachine _stateMachine;

    public KeyboardInputHandler(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Handle()
    {
        CheckForSwipe();

        CheckForJump();

        CheckForSlide();
    }

    private void CheckForSwipe()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _stateMachine.SetState<SlideToLeftState>();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _stateMachine.SetState<SlideToRightState>();
        }
    }

    private void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _stateMachine.SetState<JumpState>();
        }
    }

    private void CheckForSlide()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _stateMachine.SetState<SlideDownState>();
        }
    }
}
