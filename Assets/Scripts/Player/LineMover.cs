using UnityEngine;

public class LineMover : MonoBehaviour
{
    [SerializeField, Range(1, 5)] private int _amountOfLines = 3;
    [SerializeField, Range(1f, 5f)] private float _step = 1.5f;

    private float[] _lines;
    private int _currentPosition;

    private void Awake()
    {
        _lines = new float[_amountOfLines];

        float startPoint = -(float)(_amountOfLines / 2) * _step;

        for (int i = 0; i < _amountOfLines; i++)
        {
            _lines[i] = startPoint + _step * i;
        }

        _currentPosition = (_amountOfLines + 1) / 2 - 1;
    }

    public void TryMoveLeft()
    {
        if (_currentPosition <= 0)
        {
            return;
        }

        _currentPosition--;
        transform.position = new Vector3(_lines[_currentPosition], transform.position.y, transform.position.z);
    }

    public void TryMoveRight()
    {
        if (_currentPosition >= _amountOfLines - 1)
        {
            return;
        }

        _currentPosition++;
        transform.position = new Vector3(_lines[_currentPosition], transform.position.y, transform.position.z);
    }
}
