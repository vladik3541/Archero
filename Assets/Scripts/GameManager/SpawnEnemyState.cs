
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class SpawnEnemyState : State
{
    public event Action OnEndWave;
    private GameManager _gameManager;
    public int currentWave = 0;
    private int _enemiesAlive = 0;
    public SpawnEnemyState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public override void Enter()
    {
        SpawnWave();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
    void SpawnWave()
    {
        for (int i = 0; i < _gameManager.wave.Length; i++)
        {
            Vector3 newPosition;

            newPosition.x = Random.Range(_gameManager.walls[0].position.x, _gameManager.walls[2].position.x);
            newPosition.z = Random.Range(_gameManager.walls[0].position.z, _gameManager.walls[2].position.z);
            newPosition.y = 1;

            GameObject enemy = Object.Instantiate(_gameManager.wave[currentWave].enemy[i].gameObject);
            enemy.transform.position = newPosition;

            _enemiesAlive++;
            enemy.GetComponent<Health>().OnDeath += EnemyDestroyed;
        }
    }
    void EnemyDestroyed()
    {
        _enemiesAlive--;
        if (_enemiesAlive <= 0)
        {
            // Всі вороги знищені
            OnAllEnemiesDestroyed();
        }
    }

    void OnAllEnemiesDestroyed()
    {
        // Код, який виконується, коли всі вороги знищені
        OnEndWave?.Invoke();
        Debug.Log("Всі вороги знищені!");
    }
}
