using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private IInput input;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        input = FindObjectOfType<DesktopInput>();
        FindComponents();
        playerController.Initialize(input);
        gameManager.Initialize(playerController);
    }

    private void FindComponents()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
    }
}
