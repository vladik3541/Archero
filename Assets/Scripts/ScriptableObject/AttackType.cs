using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackType", menuName = "Attack/AttackType")]
public class AttackType : ScriptableObject
{
    public string attackName;
    public float damage;
    public float attackSpeed;
    public GameObject projectilePrefab; // Префаб для проектиля
}
