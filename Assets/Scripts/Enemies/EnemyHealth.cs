using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float dmg;

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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player Bullet"))
        {
            if (Conductor.Instance.lessDmgOn)
            {
                Destroy(gameObject);
            }
            else if (Conductor.Instance.fullDmgOn)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Damage(float damage)
    {
        Debug.Log(damage);
        currentHealth -= damage;
        Conductor.Instance.lessDmgOn = false;
        Conductor.Instance.fullDmgOn = false;
    }
}
