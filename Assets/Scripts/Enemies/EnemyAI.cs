using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;

    public float speed;

    public bool moveAway;

    float distance;    
    float angle;

    [SerializeField]
    float distanceBetween;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (moveAway)
        {            
            if (distance < distanceBetween)
            {
                MoveAway();
            }
            else if (distance > distanceBetween)
            {
                MoveTowards();
            }
        }
        else
        {
            MoveTowards();
        }
    }

    public void MoveTowards()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void MoveAway()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, -(speed * Time.deltaTime));
    }
}
