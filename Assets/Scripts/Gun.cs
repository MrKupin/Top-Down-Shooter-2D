using System;
using System.Threading.Tasks;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public event Action OnShoot;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet[] _bullets;
    private bool _loaded = true;

    public void Shoot()
    {
        foreach (Bullet bullet in _bullets)
        {
            if (bullet.Active == false && _loaded)
            {
                bullet.SetPosition(_shootPoint.position);
                bullet.SetRotation(_shootPoint.rotation);
                bullet.Enable();
                _loaded = false;
                Reload();
                OnShoot?.Invoke();
                return;
            }
        }
    }

    private async void Reload()
    {
        await Task.Delay(300);
        _loaded = true;
    }
}
