using UnityEngine;

public class AnimationEventsHelper : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;

    public void StopSliding()
    {
        _player.StopSliding();
    }

    public void StopJumping()
    {
        _player.StopJumping();
    }
}
