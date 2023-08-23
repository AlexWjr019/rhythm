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
    private float fireForce;

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

        AudioManager.Instance.Play("Blaster");

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
