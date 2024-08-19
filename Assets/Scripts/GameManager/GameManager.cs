using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WaveConfige[] wave;
    public Transform[] walls;
    public float timeWaiteBetweenWave = 3f;

    private StateMachine stateMachine;

    public StateMachine StateMachine { get { return stateMachine; } }
    private SpawnEnemyState spawnEnemyState;
    private CollectCoinState collectCoinState;



    public void Initialize()
    {
        stateMachine = new StateMachine();
        spawnEnemyState = new SpawnEnemyState(this);
        collectCoinState = new CollectCoinState(this);

        stateMachine.InitializeState(spawnEnemyState);
        stateMachine.CurrentState.Enter();
        spawnEnemyState.OnEndWave += EndWave;
    }
    private void EndWave()
    {
        stateMachine.SwitchState(collectCoinState);
    }
   
}
