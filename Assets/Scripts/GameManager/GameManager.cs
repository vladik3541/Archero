using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WaveConfige[] wave;
    public Transform[] walls;
    public float timeWaiteBetweenWave = 3f;

    private PlayerController _playerControl;
    private StateMachine stateMachine;
    private SpawnEnemyState spawnEnemyState;
    private CollectCoinState collectCoinState;
    public StateMachine StateMachine { get { return stateMachine; } }
    public PlayerController PlayerControl { get { return _playerControl; } }


    public void Initialize(PlayerController playerControl)
    {
        _playerControl = playerControl;
        stateMachine = new StateMachine();
        spawnEnemyState = new SpawnEnemyState(this);
        collectCoinState = new CollectCoinState(this);

        stateMachine.InitializeState(spawnEnemyState);
        spawnEnemyState.OnEndWave += EndWave;
        collectCoinState.OnEndMoveCoin += EndCollectCoin;
    }
    private void EndWave()
    {
        stateMachine.SwitchState(collectCoinState);
    }
    private void EndCollectCoin()
    {
        stateMachine.SwitchState(spawnEnemyState);
    }

    private void OnDisable()
    {
        spawnEnemyState.OnEndWave -= EndWave;
    }
}
