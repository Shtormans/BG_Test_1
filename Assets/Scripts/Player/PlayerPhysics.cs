using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerPhysics : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)] private float _initialSpeed = 4f;
    [SerializeField, Range(0.01f, 3f)] private float _secondsToIncreasingSpeed = 0.05f;
    [SerializeField, Range(0f, 5f)] private float _speedIncreaseValue = 0.1f;

    private float _additionSpeed;
    private Coroutine _addToSpeedCoroutine;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _additionSpeed = 0;
    }

    private void OnEnable()
    {
        _addToSpeedCoroutine = StartCoroutine(AddToSpeed());
    }

    private void OnDisable()
    {
        if (_addToSpeedCoroutine != null)
        {
            StopCoroutine(_addToSpeedCoroutine);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var velocity = _rigidbody.velocity;
        velocity.z = _initialSpeed + _additionSpeed;

        _rigidbody.velocity = velocity;
    }

    private IEnumerator AddToSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(_secondsToIncreasingSpeed);

            _additionSpeed += _speedIncreaseValue;
        }
    }
}
