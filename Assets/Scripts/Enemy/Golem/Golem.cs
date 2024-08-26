using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    [SerializeField] private int damage;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private ProjectileTurtle _projectile;
    [SerializeField] private Transform firePoint;

    [SerializeField] private PlayerController playerController;

    protected override void Start()
    {
        base.Start();
        playerController = FindObjectOfType<PlayerController>();

    }
    private void Update()
    {
        RotateTarget();
    }
    private void RotateTarget()
    {
        Vector3 direction = playerController.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction.normalized);
    }
    // Метод для атаки
    public void Attack()
    {
        ShootProjectile(-45f); // Перший снаряд летить вліво
        ShootProjectile(0f);   // Другий снаряд летить прямо
        ShootProjectile(45f);   // Третій снаряд летить вправо
    }

    // Метод для створення і запуску снаряда
    void ShootProjectile(float angle)
    {
        // Створення нового снаряда
        ProjectileTurtle projectile = Instantiate(_projectile, firePoint.position, transform.rotation);
        // Поворот снаряда під заданим кутом відносно точки запуску
        projectile.transform.Rotate(0f, angle, 0f);

        projectile.StartMove(damage, projectileSpeed);
    }
}
