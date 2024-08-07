using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float _damage;
    public float Damage 
    {
        get { return _damage; }
        set { _damage = value; }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damage);
            Destroy(gameObject);
        }
        
    }
}
