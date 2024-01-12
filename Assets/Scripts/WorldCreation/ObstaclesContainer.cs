using System.Collections.Generic;
using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    [SerializeField] private ObstaclesPool _pool;
    [SerializeField] private Floor _firstChunk;
    private LinkedList<Floor> _chunks;

    public Vector3 FirstPoint => _chunks.First.Value.StartPoint;

    private void Awake()
    {
        _chunks = new LinkedList<Floor>();
    }

    public void AddNewChunk()
    {
        var chunk = _pool.GetRandom();

        chunk.gameObject.SetActive(true);

        if (_chunks.Count != 0)
        {
            chunk.transform.position = _chunks.Last.Value.EndPoint + chunk.transform.position - chunk.StartPoint;
        }
        else
        {
            chunk.transform.position = _firstChunk.EndPoint + chunk.transform.position - chunk.StartPoint;
        }

        _chunks.AddLast(chunk);
    }

    public void RemoveChunks(Vector3 toPosition)
    {
        var chunk = _chunks.First;

        while (_chunks.Count != 0 && chunk.Value.EndPoint.z < toPosition.z)
        {
            _pool.ReturnToPool(chunk.Value);
            _chunks.RemoveFirst();

            chunk = _chunks.First;

            AddNewChunk();
        }
    }

    public void ChangeFirstChunksToSafe(int amount)
    {
        int index = 0;

        var chunk = _chunks.First;
        while (_chunks.Count != index && index < amount)
        {
            chunk.Value.DeleteObstacles();
            chunk = chunk.Next;
            index++;
        }
    }
}
