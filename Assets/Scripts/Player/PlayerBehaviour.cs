using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour, IGamePauseSubscriber
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PauseGameManager _pauseGameManager;
    [SerializeField] private PlayerStateMachine _stateMachine;

    private PlayerPhysics _physics;
    private LineMover _lineMover;
    private PlayerColliderController _colliderController;
    private PlayerInputManager _inputManager;
    private Rigidbody _rigidbody;

    private bool _isJumping;
    private bool _isSliding;

    public event Action StartedMoving;
    public event Action Died;

    public Animator Animator => _animator;
    public bool IsJumping => _isJumping;
    public bool IsSliding => _isSliding;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _physics = GetComponent<PlayerPhysics>();
        _lineMover = GetComponent<LineMover>();
        _colliderController = GetComponent<PlayerColliderController>();
        _inputManager = GetComponent<PlayerInputManager>();

        _isJumping = false;
    }

    private void OnEnable()
    {
        _pauseGameManager.Paused += Pause;
        _pauseGameManager.Resumed += Resume;
    }

    private void OnDisable()
    {
        _pauseGameManager.Paused -= Pause;
        _pauseGameManager.Resumed -= Resume;
    }

    public void StartMoving()
    {
        StartRunning();
        Resume();

        StartedMoving?.Invoke();
    }

    public void StartJumping()
    {
        if (_isJumping)
        {
            return;
        }

        _isSliding = false;
        _isJumping = true;
    }

    public void Jump()
    {
        _colliderController.Jump();
    }

    public void StartSliding()
    {
        if (_isSliding)
        {
            return;
        }

        _isJumping = false;
        _isSliding = true;
    }

    public void Slide()
    {
        _colliderController.Slide();
    }

    public void StopSliding()
    {
        _isSliding = false;
    }

    public void StopJumping()
    {
        _isJumping = false;
    }

    public void StartRunning()
    {
        _stateMachine.SetState<RunState>();
        _colliderController.MakeDefault();
    }

    public void ReturnToRun()
    {
        StopSliding();
        StopJumping();
    }

    public void SlideToRight()
    {
        _lineMover.TryMoveRight();
    }

    public void SlideToLeft()
    {
        _lineMover.TryMoveLeft();
    }

    public void Die()
    {
        _stateMachine.SetState<DieState>();
        _physics.enabled = false;
        _lineMover.enabled = false;
        _colliderController.enabled = false;
        _inputManager.enabled = false;

        _rigidbody.isKinematic = true;
        
        Died?.Invoke();
    }

    public void Pause()
    {
        _physics.enabled = false;
        _lineMover.enabled = false;
        _colliderController.enabled = false;
        _inputManager.enabled = false;
        _rigidbody.velocity = Vector3.zero;
        _animator.enabled = false;
    }

    public void Resume()
    {
        _physics.enabled = true;
        _lineMover.enabled = true;
        _colliderController.enabled = true;
        _inputManager.enabled = true;
        _animator.enabled = true;
    }

    public void Revive()
    {
        _stateMachine.SetState<ReviveState>();
        _rigidbody.isKinematic = false;
        Resume();

        StartedMoving?.Invoke();
    }
}
