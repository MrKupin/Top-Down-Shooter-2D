using System;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    public event Action OnKill;
    [SerializeField] private Gun _gun;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerCommentator _playerCommentator;

    private void Start()
    {
        _gun.OnShoot += _playerCommentator.CommentShoot;
    }

    public void Shoot()
    {
        _gun.Shoot();
    }

    public void Move(Vector2 direction)
    {
        _movement.Move(direction);
        _playerCommentator.CommentMove();
    }

    public void Rotate(Vector3 rotation)
    {
        _movement.Rotate(rotation);
        _playerCommentator.CommentRotate();
    }

    public void Kill()
    {
        OnKill?.Invoke();
    }

    private void OnDisable()
    {
        _gun.OnShoot -= _playerCommentator.CommentShoot;
    }
}
