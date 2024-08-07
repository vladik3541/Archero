using UnityEngine;

public class DesktopInput : MonoBehaviour, IInput
{
    public Vector2 GetDirection()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
