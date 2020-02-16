using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int fireRate = 5;
    public float bulletForce = 20f;

    float initialTime;

    // Start is called before the first frame update
    private void Start()
    {
        // Saving the time when the script starts
        initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float shootTime;
        float shootDelay;

        // Defining the shoot Delay and the time passed since initialTime
        shootTime = Time.time - initialTime;
        shootDelay = 1f / fireRate;

        // We shoot as long as Fire1 (LMB) is pressed AND shootDelay has passed
        if (shootTime >= shootDelay)
        {
            Shoot();
            initialTime = Time.time;
        }
    }

    // function which instantiate the bullet prefab
    void Shoot()
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
