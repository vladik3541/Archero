using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private IInput input;
    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        input = FindObjectOfType<DesktopInput>();
        playerController = FindObjectOfType<PlayerController>();
        playerController.Initialize(input);
    }
}
