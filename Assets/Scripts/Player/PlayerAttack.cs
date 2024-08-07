using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AttackType baseAttack; // Базовий тип атаки
    public List<AttackModifier> attackModifiers; // Список модифікаторів атаки
    [SerializeField] private Transform firePoint;

    private float nextAttackTime = 0f;
    private Animator animator;
    private const string nameAnimationAttack = "Standing Aim Recoil";
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Attack()
    {
        PerformAttack();
        nextAttackTime = Time.time + 1f / GetModifiedAttackSpeed();
    }

    void PerformAttack()
    {
        float modifiedDamage = GetModifiedDamage();
        int totalProjectiles = 1 + GetExtraProjectiles();

        for (int i = 0; i < totalProjectiles; i++)
        {
            // Логіка стрільби проектилем з різними кутами
            Vector3 direction = Quaternion.Euler(0, (i - totalProjectiles / 2) * 10, 0) * transform.forward;
            GameObject projectile = Instantiate(baseAttack.projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
            projectile.GetComponent<Projectile>().Damage = modifiedDamage;
        }

        Debug.Log($"Attacking with {baseAttack.attackName} dealing {modifiedDamage} damage per projectile.");
    }

    float GetModifiedDamage()
    {
        float damage = baseAttack.damage;
        foreach (var modifier in attackModifiers)
        {
            damage *= modifier.damageMultiplier;
        }
        return damage;
    }

    float GetModifiedAttackSpeed()
    {
        float attackSpeed = baseAttack.attackSpeed;
        foreach (var modifier in attackModifiers)
        {
            attackSpeed *= modifier.attackSpeedMultiplier;
        }
        SetSpecificAnimationSpeed(nameAnimationAttack, attackSpeed);
        return attackSpeed;
    }

    int GetExtraProjectiles()
    {
        int extraProjectiles = 0;
        foreach (var modifier in attackModifiers)
        {
            extraProjectiles += modifier.extraProjectiles;
        }
        return extraProjectiles;
    }

    public void AddAttackModifier(AttackModifier newModifier)
    {
        attackModifiers.Add(newModifier);
        Debug.Log($"Added modifier: {newModifier.modifierName}");
    }
    public void SetSpecificAnimationSpeed(string animationName, float speed)
    {
        AnimatorOverrideController overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        foreach (AnimationClip clip in overrideController.animationClips)
        {
            if (clip.name == animationName)
            {
                clip.frameRate = speed * clip.frameRate / overrideController[clip].frameRate;
                break;
            }
        }
    }
}
