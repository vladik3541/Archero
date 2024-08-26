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
    private const int ANGLE_ARROW = 45;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Attack()
    {
        float modifiedDamage = GetModifiedDamage();
        int totalProjectilesDiagonal = GetExtraProjectiles();
        int totalProjectilesFront = 2;


        Multishot(modifiedDamage, totalProjectilesFront);
        PerformAttack(totalProjectilesDiagonal, modifiedDamage);
        nextAttackTime = Time.time + 1f / GetModifiedAttackSpeed();
    }

    void PerformAttack(int totalProjectiles, float modifiedDamage)
    {
        for (int i = 0; i < totalProjectiles; i++)
        {
            // Розрахунок кута для кожного проектиля
            float angle = CalculateProjectileAngle(i, totalProjectiles);

            // Логіка стрільби проектилем з розрахованим кутом
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            GameObject projectile = Instantiate(baseAttack.projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
            projectile.GetComponent<Projectile>().Damage = modifiedDamage;
        }

        Debug.Log($"Attacking with {baseAttack.attackName} dealing {modifiedDamage} damage per projectile.");
    }
    float CalculateProjectileAngle(int index, int totalProjectiles)
    {
        if (totalProjectiles <= 1)
            return 0f;

        float maxAngle = 45f * (totalProjectiles - 1) / 2;
        float step = 45f;

        // Розрахунок кута для кожного проектиля
        return maxAngle - (step * index);
    }
    void Multishot(float modifiedDamage, int totalProjectileFront)
    {
        Vector3 direction = transform.forward;
        Vector3 newPoint = new Vector3(0.45f, 0,0);
        if(totalProjectileFront == 1)
        {
            GameObject projectile = Instantiate(baseAttack.projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
            projectile.GetComponent<Projectile>().Damage = modifiedDamage;
        }
        else if(totalProjectileFront == 2)
        {
            Instantiate(baseAttack.projectilePrefab, firePoint.position + newPoint, Quaternion.LookRotation(direction));
            Instantiate(baseAttack.projectilePrefab, firePoint.position - newPoint, Quaternion.LookRotation(direction));
        }
        
        // Логіка стрільби проектилем з розрахованим кутом

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
