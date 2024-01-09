using UnityEngine;

public class LineMover : MonoBehaviour
{
    [SerializeField, Range(1, 5)] private int _amountOfLines = 3;
    [SerializeField, Range(1f, 25f)] private float _step = 1.5f;
    [SerializeField, Range(0f, 5f)] private float _transitionTime = 0.3f;

    private float[] _lines;
    private int _currentPosition;
    private int _newPosition;

    private void Awake()
    {
        _lines = new float[_amountOfLines];

        float startPoint = -(float)(_amountOfLines / 2) * _step;

        for (int i = 0; i < _amountOfLines; i++)
        {
            _lines[i] = startPoint + _step * i;
        }

        _currentPosition = (_amountOfLines + 1) / 2 - 1;
        _newPosition = _currentPosition;
    }

    private void Update()
    {
        if (_newPosition == _currentPosition)
        {
            return;
        }

        float x = Mathf.Lerp(transform.position.x, _lines[_newPosition], _transitionTime);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if (Mathf.Abs(transform.position.x - _lines[_newPosition]) < 0.01f)
        {
            _currentPosition = _newPosition;
        }
    }

    public void TryMoveLeft()
    {
        if (_currentPosition <= 0)
        {
            return;
        }

        _newPosition = _currentPosition - 1;
    }

    public void TryMoveRight()
    {
        if (_currentPosition >= _amountOfLines - 1)
        {
            return;
        }

        _newPosition = _currentPosition + 1;
    }
}
