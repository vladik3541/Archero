using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI healthText;
    private PlayerHealth playerHealth;
    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
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
        healthText.text = amount.ToString();
        slider.value = amount;
    }
    private void UpdateHealthPlayer(float amount)
    {
        healthText.text = amount.ToString();
        slider.value = amount;
    }

}
