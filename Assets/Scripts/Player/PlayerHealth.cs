using UnityEngine;
[RequireComponent(typeof(PlayerHealthView))]

public class PlayerHealth : Health
{
    protected override void Die()
    {
        throw new System.NotImplementedException();
    }
}
