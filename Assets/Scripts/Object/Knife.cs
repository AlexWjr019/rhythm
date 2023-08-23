using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public ParticleSystem blood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //CreateBlood();
            //AudioManager.Instance.Play("Hurt");

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(collision.gameObject.GetComponent<PlayerHealth>().dmg);
        }
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
