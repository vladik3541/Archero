using DG.Tweening;
using UnityEngine;

public abstract class Enemy : Health
{
    [SerializeField] private int coinCount;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private ParticleSystem effectDie;
    private float timeToDestroy = 2;
    protected Animator animator;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    protected override void Die()
    {
        ParticleSystem effect = Instantiate(effectDie, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 1);
        SpawnCoins();
    }
    private void SpawnCoins()
    {
        if (coinPrefab != null)
        {
            for (int i = 0; i < coinCount; i++)
            {
                GameObject clone = Instantiate(coinPrefab, transform.position, coinPrefab.transform.rotation);
                Vector3 randomPosition = new Vector3(Random.Range(-2, 3), 0, Random.Range(-2, 3));
                clone.transform.DOJump(transform.position + randomPosition, 3, 3, 1);
                Debug.LogError("Coin");
            }
        }
    }
}
