using UnityEngine;

public class ProjectileBeholder : Projectile
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if(other.CompareTag("Ground"))
        {
            Destroy(gameObject);
            print("Ground");
        }
    }
}
