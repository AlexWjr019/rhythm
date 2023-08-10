using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    bool canFire;
    [SerializeField]
    float firingDelay;
    float firingTimer;

    void Update()
    {
        if (!canFire)
        {
            firingTimer += Time.deltaTime;
            if(firingTimer > firingDelay)
            {
                canFire = true;
                firingTimer = 0;
            }
        }

        if (Input.GetMouseButton(0)  && canFire)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        canFire = false;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
