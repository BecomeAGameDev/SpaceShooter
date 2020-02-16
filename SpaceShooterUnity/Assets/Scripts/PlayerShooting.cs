using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePointSx;
    public Transform firePointDx;
    public GameObject bulletPrefab;

    public int fireRateSx;
    public int fireRateDx;
    public int bulletForceSx;
    public int bulletForceDx;

    float initialTimeSx;
    float initialTimeDx;

    class weapon // TODO: fare classe gestione arma
    {

    }

    // Start is called before the first frame update
    private void Start()
    {
        // Saving the time when the script starts
        initialTimeSx = Time.time;
        initialTimeDx = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float shootTime;
        float shootDelay;

        // Getting properties from WeaponStats.cs
        // TODO: sarebbe bello spostare questi in una funzione che si attivi solo se cambiano
        fireRate = 5;
        bulletForce = 20;

        // Defining the shoot Delay and the time passed since initialTime
        shootTime = Time.time - initialTime;
        shootDelay = 1f / fireRate;

        // We shoot as long as Fire1 (LMB) is pressed AND shootDelay has passed
        if (Input.GetButton("Fire1") && shootTime >= shootDelay)
        {
            shoot();
            initialTime = Time.time;
        }

        if (Input.GetButton("Fire2") && shootTime >= shootDelay)
        {
            shoot();
            initialTime = Time.time;
        }
    }

    // function which instantiate the bullet prefab
    void shoot()
    {
        GameObject bullet;
        Rigidbody2D rb;

        // the bullet's position and rotation is defined by the firePoint object
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        rb = bullet.GetComponent<Rigidbody2D>();

        // The force of fire is given with Impulse mode
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
