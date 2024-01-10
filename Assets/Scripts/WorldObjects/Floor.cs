using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private List<Obstacle> _obstacles;

    public Vector3 StartPoint => _startPoint.position;
    public Vector3 EndPoint => _endPoint.position;

    private void OnEnable()
    {
        foreach (var obstacle in _obstacles)
        {
            obstacle.gameObject.SetActive(true);
        }
    }

    public void DeleteObstacles()
    {
        foreach (var obstacle in _obstacles)
        {
            obstacle.gameObject.SetActive(false);
        }
    }
}
