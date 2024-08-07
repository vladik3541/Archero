using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target == null) return;

        // ���������� ������� �������
        Vector3 desiredPosition = target.position + offset;

        // �������� ������� �������
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.z = Mathf.Clamp(desiredPosition.z, minBounds.y, maxBounds.y);

        // ������ ��������� ������ �� ������� �������
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1 / smoothSpeed);

        // ����������� ���� ������� �� ������
        transform.position = smoothedPosition;
    }
}