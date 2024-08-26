using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Beholder : Enemy
{
    [SerializeField] private float durationSpeedProjectile;
    [SerializeField] private float powerJumpProjectile;
    [SerializeField] private int damage;
    [SerializeField] private int coutProjectile;
    [SerializeField] private float attackInterval;
    [SerializeField] private float spawnProjectileInterval;

    [SerializeField] private Projectile projectile;
    private PlayerController playerController;

    private int numJump = 1;
    protected override void Start()
    {
        base.Start();
        playerController = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
        InvokeRepeating("Attack", attackInterval, attackInterval);
    }
    public void Attack()
    {
        StartCoroutine(SpawnProjectile());
        animator.SetTrigger("Attack");
        
    }
    private void Update()
    {
        RotateTarget();
    }
    private void RotateTarget()
    {
        Vector3 direction = playerController.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction.normalized);
    }
    private IEnumerator SpawnProjectile()
    {
        Vector3 lastPalyerPosition = playerController.transform.position;
        for (int i = 0; i < coutProjectile; i++)
        {

            Projectile clone = Instantiate(projectile, transform.position + Vector3.up, transform.rotation);
            clone.GetComponent<Projectile>().Damage = damage;
            clone.transform.DOJump(lastPalyerPosition + new Vector3(Random.Range(-1,2), 0, Random.Range(-1, 2)),
                                    powerJumpProjectile,
                                    numJump, 
                                    durationSpeedProjectile);
            yield return new WaitForSeconds(spawnProjectileInterval);
        }
    }
}
