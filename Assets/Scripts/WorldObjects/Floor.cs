using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    public Vector3 StartPoint => _startPoint.position;
    public Vector3 EndPoint => _endPoint.position;
}
