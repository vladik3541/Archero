using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackModifier", menuName = "Attack/AttackModifier")]
public class AttackModifier : ScriptableObject
{
    public string modifierName;
    public int extraProjectiles; // Кількість додаткових проектилів
    public float damageMultiplier; // Множник шкоди
    public float attackSpeedMultiplier; // Множник швидкості атаки
}
