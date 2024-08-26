
using DG.Tweening;
using System;
using UnityEngine;

public class CollectCoinState : State
{
    public event Action OnAddCoin;
    public event Action OnEndMoveCoin;
    private float speed = 1f;
    private GameObject[] coins;
    private GameManager _gameManager;
    private string tagCoin = "Coin";

    public CollectCoinState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public override void Enter()
    {
        coins = GameObject.FindGameObjectsWithTag(tagCoin);
        MoveCoin();
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }


    private void MoveCoin()
    {
        foreach (var coin in coins)
        {
            coin.transform.DOMove(_gameManager.PlayerControl.transform.position, speed).SetEase(Ease.Flash).OnComplete(EndCoinMove);
        }
        OnEndMoveCoin?.Invoke();
    }

    private void EndCoinMove()
    {
        OnAddCoin?.Invoke();
    }
}
