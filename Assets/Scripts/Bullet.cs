using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;
    public bool Active => gameObject.activeInHierarchy;

    private void Start()
    {
        _direction = transform.up;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _direction * _speed;
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        _direction = transform.up;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _direction = Vector2.Reflect(_direction, collision.contacts[0].normal);
        if (collision.gameObject.TryGetComponent(out IHealth health))
            health.Kill();
    }
}
