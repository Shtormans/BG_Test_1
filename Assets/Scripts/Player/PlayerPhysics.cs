using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerPhysics : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)] private float _jumpForce = 5f;
    [SerializeField, Range(0f, 20f)] private float _initialSpeed = 4f;

    private Rigidbody _rigidbody;
    private bool _canMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        var _player = GetComponent<PlayerBehaviour>();
        _player.StartedMoving += StartMoving;

        _canMove = false;
    }

    private void FixedUpdate()
    {
        if (!_canMove)
        {
            return;
        }

        var velocity = _rigidbody.velocity;
        velocity.z = _initialSpeed;

        _rigidbody.velocity = velocity;
    }

    public void StartMoving()
    {
        _canMove = true;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
