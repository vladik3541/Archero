using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackModifier", menuName = "Attack/AttackModifier")]
public class AttackModifier : ScriptableObject
{
    public string modifierName;
    public int extraProjectiles; // ʳ������ ���������� ���������
    public float damageMultiplier; // ������� �����
    public float attackSpeedMultiplier; // ������� �������� �����
}
