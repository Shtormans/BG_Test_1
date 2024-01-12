using UnityEngine;

public class AndroidInputHandler : IInputHandler
{
    private PlayerStateMachine _stateMachine;
    private Vector2 _startTouchPosition;

    public AndroidInputHandler(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Handle()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        var touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            _startTouchPosition = touch.position;
            return;
        }

        if (touch.phase == TouchPhase.Ended)
        {
            Vector2 direction = touch.position - _startTouchPosition;

            ChooseMovement(direction);
        }
    }

    private void ChooseMovement(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SwipeRight();
            }
            else
            {
                SwipeLeft();
            }
        }
        else
        {
            if (direction.y > 0)
            {
                Jump();
            }
            else
            {
                Slide();
            }
        }
    }

    private void SwipeLeft()
    {
        _stateMachine.SetState<SlideToLeftState>();
    }

    private void SwipeRight()
    {
        _stateMachine.SetState<SlideToRightState>();
    }

    private void Jump()
    {
        _stateMachine.SetState<JumpState>();
    }

    private void Slide()
    {
        _stateMachine.SetState<SlideDownState>();
    }
}
