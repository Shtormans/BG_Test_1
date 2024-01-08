using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _lastPosition;

    private void Awake()
    {
        _lastPosition = _target.position;
    }

    private void LateUpdate()
    {
        Vector3 direction = _target.position - _lastPosition;
        direction.y = 0;

        transform.position += direction;
        _lastPosition = _target.position;
    }
}
