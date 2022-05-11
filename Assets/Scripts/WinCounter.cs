using UnityEngine;
using UnityEngine.UI;

public class WinCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Text _playerNumberWinsText;
    [SerializeField] private Text _enemyNumberWinsText;
    private int _playerNamberWins;
    private int _enemyNamberWins;

    private void Start()
    {
        _player.OnKill += CountEnemy;
        _enemy.OnKill += CountPlayer;
    }

    private void CountPlayer()
    {
        _playerNamberWins++;
        _playerNumberWinsText.text = "Player: " + _playerNamberWins.ToString();
    }

    private void CountEnemy()
    {
        _enemyNamberWins++;
        _enemyNumberWinsText.text = "Enemy: " + _enemyNamberWins.ToString();
    }

    private void OnDisable()
    {
        _player.OnKill -= CountEnemy;
        _enemy.OnKill -= CountPlayer;
    }
}
