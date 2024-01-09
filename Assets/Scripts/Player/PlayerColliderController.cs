using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class PlayerColliderController : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _defaultCollider;
    [SerializeField] private CapsuleCollider _slideCollider;
    [SerializeField] private CapsuleCollider _jumpCollider;

    private PlayerBehaviour _playerBehaviour;

    private void Awake()
    {
        _playerBehaviour = GetComponent<PlayerBehaviour>();
    }

    public void Slide()
    {
        _slideCollider.enabled = true;
        _defaultCollider.enabled = false;
        _jumpCollider.enabled = false;
    }

    public void Jump()
    {
        _jumpCollider.enabled = true;
        _defaultCollider.enabled = false;
        _slideCollider.enabled = false;
    }

    public void MakeDefault()
    {
        _defaultCollider.enabled = true;
        _jumpCollider.enabled = false;
        _slideCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Obstacle obstacle))
        {
            _playerBehaviour.Die();
        }
    }
}
