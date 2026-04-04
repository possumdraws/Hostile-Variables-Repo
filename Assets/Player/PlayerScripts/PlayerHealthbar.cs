using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image healthColor;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        healthColor.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        healthColor.color = gradient.Evaluate(slider.normalizedValue);
    }
}
