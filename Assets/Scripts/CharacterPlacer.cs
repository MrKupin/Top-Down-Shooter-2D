using UnityEngine;

public class CharacterPlacer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _playerStartPoint;
    [SerializeField] private Transform _enemyStartPoint;

    private void Start()
    {
        _player.OnKill += Put;
        _enemy.OnKill += Put;
        Put();
    }

    private void Put()
    {
        _player.transform.position = _playerStartPoint.position;
        _player.transform.rotation = _playerStartPoint.rotation;
        _enemy.transform.position = _enemyStartPoint.transform.position;
        _enemyStartPoint.transform.rotation = _enemyStartPoint.transform.rotation;
    }
}
