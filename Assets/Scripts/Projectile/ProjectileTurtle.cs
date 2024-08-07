using System.Collections;
using UnityEngine;

public class ProjectileTurtle : Projectile
{
    private float _speed;
    private Vector3 _direction;
    public void StartMove(int damage, float speed)
    {
        _damage = damage;
        _speed = speed;
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        while (true)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            yield return null;
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    private void OnDisable()
    {
        StopCoroutine(Move());
    }
}
