using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthView : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private Health playerHealth;
    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        playerHealth.OnChange += UpdateHealthPlayer;
        playerHealth.OnChangeMaxHealth += UpdateMaxHealth;
    }
    private void OnDisable()
    {
        playerHealth.OnChange -= UpdateHealthPlayer;
        playerHealth.OnChangeMaxHealth -= UpdateMaxHealth;
    }
    private void UpdateMaxHealth(float amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }
    private void UpdateHealthPlayer(float amount)
    {
        slider.value = amount;
    }
}
