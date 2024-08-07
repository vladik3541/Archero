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

        // ѕерев≥р€Їмо дистанц≥ю до гравц€
        if (Vector3.Distance(transform.position, player.transform.position) <= checkDistance)
        {
            // якщо занадто близько, зм≥нюЇмо напр€мок
            direction = -direction;
        }
        transform.rotation = Quaternion.LookRotation(direction);
        targetPosition = transform.position + direction * jumpDistance;

        // ѕерев≥р€Їмо, чи Ї м≥сце дл€ стрибка
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, jumpDistance, layerMask))
        {
            // «м≥нюЇмо напр€мок, €кщо шл€х блокуЇтьс€
            Debug.Log("Detect");
            /*direction = new Vector3(direction.z, direction.y, -direction.x);
            targetPosition = transform.position + direction * jumpDistance;*/
            targetPosition = hit.point;
        }
        return targetPosition;
    }
}
