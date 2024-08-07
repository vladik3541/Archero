using DG.Tweening;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Turtle : Enemy
{
    [SerializeField] private PlayerController player; // Посилання на гравця
    [SerializeField] private float jumpPower = 2f; // Сила стрибка
    [SerializeField] private int numJumps = 1; // Кількість стрибків
    [SerializeField] private float jumpDuration = 1f; // Тривалість стрибка
    [SerializeField] private float checkDistance = 2f; // Мінімальна дистанція до гравця, при якій змінюється напрямок
    [SerializeField] private float jumpInterval = 1f; // Інтервал між стрибками
    [Header("Attack")]
    [SerializeField] private int damage;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private int countBullet = 4;
    [SerializeField] private ProjectileTurtle _projectile;
    [SerializeField] private int rotateAngle = 90;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Jump), 0f, jumpInterval);
    }

    private void Jump()
    {
        // Встановлюємо нову позицію по X як у гравця
        float newX = player.transform.position.x;

        // Випадково вибираємо нову позицію по Z: +1 або -1 від поточної позиції
        float newZ = transform.position.z + (Random.Range(0, 2) == 0 ? -1f : 1f);

        Vector3 targetPosition = new Vector3(newX, transform.position.y , newZ);

        // Виконуємо стрибок і викликаємо метод атаки після завершення стрибка
        transform.DOJump(targetPosition, jumpPower, numJumps, jumpDuration).SetEase(Ease.Flash).OnComplete(Attack);
    }
    public void Attack()
    {
        for (int i = 0; i < countBullet; i++)
        {
            ProjectileTurtle project = Instantiate(_projectile);

            project.transform.position = transform.position + Vector3.up;

            project.transform.Rotate(0, i * rotateAngle, 0);

            project.StartMove(damage, projectileSpeed);
        }

    }
}
