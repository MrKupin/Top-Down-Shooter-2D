using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public void Move(Vector3 direction)
    {
        _rigidbody2D.MovePosition(transform.position + transform.TransformDirection(direction) * _moveSpeed);
        if (direction == Vector3.zero)
            _rigidbody2D.velocity = Vector3.zero;
    }

    public void Rotate(Vector3 rotation)
    {
        transform.Rotate(rotation * _rotationSpeed);
    }
}
