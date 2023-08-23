using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float dmg;

    [SerializeField]
    int points;

    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            ScoreManager.Instance.AddPoint(points);
            AudioManager.Instance.Play("Destroy");
            Destroy(gameObject);
        }
    }

    public void Damage(float damage)
    {
        if (Conductor.Instance.lessDmgOn && !Conductor.Instance.fullDmgOn)
        {
            currentHealth -= damage / 2;
            healthBar.SetHealth(currentHealth);
        }
        else if (!Conductor.Instance.lessDmgOn && Conductor.Instance.fullDmgOn)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
}
