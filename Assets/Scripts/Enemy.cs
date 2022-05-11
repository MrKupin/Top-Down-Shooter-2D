using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    public event Action OnKill;
    [SerializeField] private Gun _gun;
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private Player _player;

    private void Start()
    {
        _movement.Follow();
        _movement.OnStopFollow += _gun.Shoot;
        _gun.OnShoot += _movement.RunAway;
        _movement.OnStopRunAway += _movement.Follow;
    }

    public void Kill()
    {
        OnKill?.Invoke();
    }

    private void OnDisable()
    {
        _movement.OnStopFollow -= _gun.Shoot;
        _gun.OnShoot -= _movement.RunAway;
        _movement.OnStopRunAway -= _movement.Follow;
    }
}
