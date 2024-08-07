using DG.Tweening;
using System;
using UnityEngine;

public class Slime : Enemy
{
    [Header("Movement")]
    [SerializeField] private float jumpDistance;
    [SerializeField] private float jumpPower;
    [SerializeField] private int damageCollision;
    [SerializeField] private float checkDistance;
    [SerializeField] private float jumpInterval;
    [SerializeField] private float jumpDuration;
    [Space(25)]
    [SerializeField] private PlayerController player;
    [SerializeField] private LayerMask layerMask; 

    private int numJumps = 1;
    private Vector3 targetPosition;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("Movement", 0f, jumpInterval);
    }

    private void Movement()
    {
        transform.DOJump(GetNewPosition(), jumpPower, numJumps, jumpDuration).SetEase(Ease.Flash);
    }
    private Vector3 GetNewPosition()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // ���������� ��������� �� ������
        if (Vector3.Distance(transform.position, player.transform.position) <= checkDistance)
        {
            // ���� ������� �������, ������� ��������
            direction = -direction;
        }
        transform.rotation = Quaternion.LookRotation(direction);
        targetPosition = transform.position + direction * jumpDistance;

        // ����������, �� � ���� ��� �������
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, jumpDistance, layerMask))
        {
            // ������� ��������, ���� ���� ���������
            Debug.Log("Detect");
            /*direction = new Vector3(direction.z, direction.y, -direction.x);
            targetPosition = transform.position + direction * jumpDistance;*/
            targetPosition = hit.point;
        }
        return targetPosition;
    }
}
