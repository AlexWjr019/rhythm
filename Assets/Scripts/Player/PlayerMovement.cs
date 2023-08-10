using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //public ParticleSystem trail;

    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    void Update()
    {
        ProcessInputs();

        //if (moveDirection != Vector2.zero)
        //{
        //    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.Euler(0, 0, angle);
        //    //CreateTrail();
        //}

        Vector2 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    //void CreateTrail()
    //{
    //    trail.Play();
    //}
}
