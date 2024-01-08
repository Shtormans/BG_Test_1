using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private PlayerPhysics _physics;
    private LineMover _lineMover;

    private bool _canJump;

    public event Action StartedMoving;

    public Animator Animator => _animator;

    private void Awake()
    {
        _physics = GetComponent<PlayerPhysics>();
        _lineMover = GetComponent<LineMover>();

        _canJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Floor>(out Floor floor))
        {
            _canJump = true;
        }
    }

    public void StartMoving()
    {
        StartedMoving?.Invoke();
    }

    public void Jump()
    {
        _physics.Jump();

        _canJump = false;
    }

    public void SlideToRight()
    {
        _lineMover.TryMoveRight();
    }

    public void SlideToLeft()
    {
        _lineMover.TryMoveLeft();
    }
}
