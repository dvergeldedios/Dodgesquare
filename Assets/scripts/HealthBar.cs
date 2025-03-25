using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image FillImage;
    public Slider PlayerHealthBar;

    // Start
    public void SetMaxHealth(int maxHealth)
    {
        PlayerHealthBar.maxValue = maxHealth;
        PlayerHealthBar.value = maxHealth;
    }

    // call in playermovement.cs whenever health changes
    public void SetHealth(int currentHealth)
    {
        PlayerHealthBar.value = currentHealth;
    }

    public void UpdateFillColor()
    {
        float hpPercent = PlayerHealthBar.value / PlayerHealthBar.maxValue;

        if (PlayerHealthBar.value <= 0)
            FillImage.color = Color.black;
        else if (hpPercent <= 0.30f)
            FillImage.color = Color.red;
        else if (hpPercent <= 0.70f)
            FillImage.color = Color.yellow;
        else
            FillImage.color = Color.green;
    }
}
