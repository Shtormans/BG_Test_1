using UnityEngine;
using DG.Tweening;

public class UIStartTransition : MonoBehaviour
{
    [SerializeField] private float _startX = -1200f;
    [SerializeField] private float _destinationX = 0f;
    [SerializeField] private float _durationInSeconds = 0.8f;

    private void OnEnable()
    {
        transform.position = new Vector3(_startX, transform.position.y, 0f);

        transform.DOLocalMoveX(_destinationX, _durationInSeconds);
    }
}
