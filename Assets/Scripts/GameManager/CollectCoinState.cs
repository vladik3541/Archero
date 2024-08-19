
public class CollectCoinState : State
{
    private Transform coins;
    private GameManager _gameManager;
    private string tagCoin = "Coin";

    public CollectCoinState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public override void Enter()
    {
        coins = GameObject.FindObjectsWithTag(tagCoin).transform;
        
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
