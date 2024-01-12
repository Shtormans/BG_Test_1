using UnityEngine;
using DG.Tweening;

public class UIStartTransition : MonoBehaviour
{
    [SerializeField] private float _destinationX = 0f;
    [SerializeField] private float _durationInSeconds = 0.8f;

    private void OnEnable()
    {
        float leftBoundOfScreen = (Screen.width + Screen.width / 2) * -1;

        transform.DOMoveX(leftBoundOfScreen, 0f);
        transform.DOLocalMoveX(_destinationX, _durationInSeconds);
    }
}
