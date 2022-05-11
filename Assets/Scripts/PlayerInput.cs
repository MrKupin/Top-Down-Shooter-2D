using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) Move();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) Rotate();
    }

    private void Shoot()
    {
        _player.Shoot();
    }

    private void Move()
    {
        float value = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(0, value);
        _player.Move(direction);
    }

    private void Rotate()
    {
        float value = Input.GetAxis("Horizontal");
        Vector3 rotation = new Vector3(0, 0, value);
        _player.Rotate(rotation);
    }
}
