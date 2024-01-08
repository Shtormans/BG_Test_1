using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private int _startAmount = 40;
    [SerializeField] private List<Floor> _chunkStyles;

    private List<Floor> _nonActiveChunks;
    private List<Floor> _activeChunks;

    private void Awake()
    {
        _nonActiveChunks = new List<Floor>(_startAmount);
        _activeChunks = new List<Floor>(_startAmount);
    }

    private void OnEnable()
    {
        int index = 0;

        for (int i = 0; i < _startAmount; i++)
        {
            var chunk = Instantiate(_chunkStyles[index].gameObject, Vector3.zero, Quaternion.identity);
            chunk.SetActive(false);

            var floor = chunk.GetComponent<Floor>();

            _nonActiveChunks.Add(floor);

            index = (index + 1) % _chunkStyles.Count;
        }
    }

    public void CreateNewChunk()
    {
        var index = Random.Range(0, _chunkStyles.Count - 1);

        var chunk = Instantiate(_chunkStyles[index].gameObject, Vector3.zero, Quaternion.identity);
        chunk.SetActive(false);

        var floor = chunk.GetComponent<Floor>();

        _nonActiveChunks.Add(floor);
    }

    public Floor GetRandom()
    {
        if (_nonActiveChunks.Count == 0)
        {
            CreateNewChunk();
        }

        int randomIndex = Random.Range(0, _nonActiveChunks.Count - 1);

        var floor = _nonActiveChunks[randomIndex];

        _activeChunks.Add(floor);
        _nonActiveChunks.Remove(floor);

        return floor;
    }

    public void ReturnToPool(Floor floor)
    {
        _activeChunks.Remove(floor);
        _nonActiveChunks.Add(floor);
    }
}
