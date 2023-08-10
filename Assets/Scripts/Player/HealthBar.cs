using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text healthText;

    public PlayerHealth health;

    public void Start()
    {
        healthText.text = health.currentHealth.ToString() + " / " + health.maxHealth.ToString();
    }

    public void Update()
    {
        healthText.text = health.currentHealth.ToString() + " / " + health.maxHealth.ToString();
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
