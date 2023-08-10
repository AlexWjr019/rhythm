using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float shootForce;

    [SerializeField]
    bool enemy;

    void Awake()
    {
        Destroy(gameObject, 4);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        rb.velocity = new Vector2(mousePos.x, mousePos.y).normalized * shootForce;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemy)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemy)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }
}
