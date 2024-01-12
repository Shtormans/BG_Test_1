using UnityEngine;

public class WorldMonitor : MonoBehaviour
{
    [SerializeField] private int _startAmountOfChunks = 5;
    [SerializeField] private int _amountOfChunksToMakeSafe = 2;
    [SerializeField] private ObstaclesContainer _container;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        for (int i = 0; i < _startAmountOfChunks; i++)
        {
            _container.AddNewChunk();
        }
    }

    private void Update()
    {
        _container.RemoveChunks(_camera.transform.position);
    }

    public void ChangeFirstChunksToSafe()
    {
        _container.ChangeFirstChunksToSafe(_amountOfChunksToMakeSafe);
    }
}
