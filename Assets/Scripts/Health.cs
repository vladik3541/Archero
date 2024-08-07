using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public event Action<float> OnChangeMaxHealth;
    public event Action<float> OnChange;
    public event Action OnDeath;

    [SerializeField] protected float _health;
    [SerializeField] protected float _healthMax;
    public float maxHealth { get => _healthMax; set => _healthMax = value; }
    public float health { get => _health; set => _health = value; }
    protected virtual void Start()
    {
        OnChangeMaxHealth?.Invoke(_healthMax);
    }
    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        if (damage < 0)
            throw new ArgumentOutOfRangeException("damage");
        _health -= damage;

        OnChange?.Invoke(_health);

        if(health <= 0)
        {
            OnDeath?.Invoke();
            Die();
        }
    }
    protected abstract void Die();


}