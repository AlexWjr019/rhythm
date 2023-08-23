using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public bool isEnemy = false;

    public ParticleSystem blood;

    void Awake()
    {
        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isEnemy)
            {
                Destroy(gameObject);
            }
            else
            {
                //CreateBlood();

                AudioManager.Instance.Play("EnemyHurt");
                collision.gameObject.GetComponent<EnemyHealth>().Damage(collision.gameObject.GetComponent<EnemyHealth>().dmg);

                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            //CreateBlood();

            AudioManager.Instance.Play("Hurt");
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(collision.gameObject.GetComponent<PlayerHealth>().dmg);

            Destroy(gameObject);
        }
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
