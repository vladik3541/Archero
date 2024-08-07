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

        // Обчислюємо цільову позицію
        Vector3 desiredPosition = target.position + offset;

        // Обмежуємо цільову позицію
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.z = Mathf.Clamp(desiredPosition.z, minBounds.y, maxBounds.y);

        // Плавно переміщуємо камеру до цільової позиції
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1 / smoothSpeed);

        // Застосовуємо нову позицію до камери
        transform.position = smoothedPosition;
    }
}