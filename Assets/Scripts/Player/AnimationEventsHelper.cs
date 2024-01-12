using UnityEngine;

public class AnimationEventsHelper : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;

    public void StartSliding()
    {
        _player.Slide();
    }

    public void StartJumping()
    {
        _player.Jump();
    }

    public void StopSliding()
    {
        _player.StopSliding();
    }

    public void StopJumping()
    {
        _player.StopJumping();
    }

    public void ReturnToRun()
    {
        _player.StartRunning();
    }
}
