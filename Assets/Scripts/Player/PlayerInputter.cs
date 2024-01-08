using UnityEngine;

public class PlayerInputter : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine _stateMachine;

    private void Update()
    {
        CheckForSwipe();

        CheckForJump();

        CheckForSlide();
    }

    public void CheckForSwipe()
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

    public void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _stateMachine.SetState<JumpState>();
        }
    }

    public void CheckForSlide()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _stateMachine.SetState<SlideDownState>();
        }
    }
}
