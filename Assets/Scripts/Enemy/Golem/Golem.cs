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
    // ����� ��� �����
    public void Attack()
    {
        ShootProjectile(-45f); // ������ ������ ������ ����
        ShootProjectile(0f);   // ������ ������ ������ �����
        ShootProjectile(45f);   // ����� ������ ������ ������
    }

    // ����� ��� ��������� � ������� �������
    void ShootProjectile(float angle)
    {
        // ��������� ������ �������
        ProjectileTurtle projectile = Instantiate(_projectile, firePoint.position, transform.rotation);
        // ������� ������� �� ������� ����� ������� ����� �������
        projectile.transform.Rotate(0f, angle, 0f);

        projectile.StartMove(damage, projectileSpeed);
    }
}
