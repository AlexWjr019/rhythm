using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public ParticleSystem blood;

    public int sceneID;

    public float maxHealth = 100;
    public float currentHealth;

    public float dmg;

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
            //SceneManager.LoadScene(sceneID);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet"))
        {
            TakeDamage(dmg);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(float damage)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
