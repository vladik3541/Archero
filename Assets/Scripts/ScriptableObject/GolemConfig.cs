
using UnityEngine;
[CreateAssetMenu( fileName = "Golem Config", menuName = "Golem Config" , order = 51)]
public class GolemConfig : ScriptableObject
{
    [Range(0, 5000)]
    [SerializeField] private int _maxHealth;
    [Range(0, 5000)]
    [SerializeField] private int _collisionDamage;
    [Range(0, 5000)]
    [SerializeField] private int _goldForKill;
    [Range(0, 5000)]
    [SerializeField] private int _expForKill;

    [SerializeField] private int _model;
    [Range(0, 5000)]
    [SerializeField] private int _damage;
    [Range(0, 100)]
    [SerializeField] private int _speed;
    [Range(0, 10)]
    [SerializeField] private int _attackCooldown;
    [Range(0, 10)]
    [SerializeField] private int _rotationSpeed;
    [Range(0, 10)]
    [SerializeField] private int _projectileConfig;

}
