using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : Projectile
{
    [SerializeField] private float speed = 10f;
    private float timeDestroy = 3f;
    private void Start()
    {
        Destroy(gameObject, timeDestroy);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        
    }
}
