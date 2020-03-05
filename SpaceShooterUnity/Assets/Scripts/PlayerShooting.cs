using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePointSx;
    public Transform firePointDx;
    public GameObject bulletPrefab;

    weapon leftWpn = new weapon();
    weapon rightWpn = new weapon();

    class weapon // TODO: aggiungere metodi get e set per le variabili e poi SPOSTARE QUESTA CLASSE IN UN FILE CHIAMATO WeaponStats.cs, strutturato come ShipStats.cs
    { 
        public int fireRate;
        public int bulletForce;

        public float initialTime;
        public float shootTime;
        public float shootDelay;
      
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Saving the time when the script starts
        leftWpn.initialTime = Time.time;
        rightWpn.initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        // Getting properties from WeaponStats.cs
        leftWpn.fireRate = 5;
        rightWpn.fireRate = 5;

        leftWpn.bulletForce = 20;
        rightWpn.bulletForce = 20;

        // Defining the shoot Delay and the time passed since initialTime
        leftWpn.shootTime = Time.time - leftWpn.initialTime;
        rightWpn.shootTime = Time.time - rightWpn.initialTime;

        leftWpn.shootDelay = 1f / leftWpn.fireRate;
        rightWpn.shootDelay = 1f / rightWpn.fireRate;

        // We shoot as long as Fire1 (LMB) is pressed AND shootDelay has passed
        if (Input.GetButton("Fire1") && leftWpn.shootTime >= leftWpn.shootDelay)
        {
            shoot(1);
            leftWpn.initialTime = Time.time;
        }

        if (Input.GetButton("Fire2") && rightWpn.shootTime >= rightWpn.shootDelay)
        {
            shoot(2);
            rightWpn.initialTime = Time.time;
        }
    }

    // function which instantiate the bullet prefab
    void shoot(int wpn)
    {
        GameObject bullet;
        Rigidbody2D rb;

        if (wpn == 1)
        {
            // the bullet's position and rotation is defined by the firePoint object
            bullet = Instantiate(bulletPrefab, firePointSx.position, firePointSx.rotation);
            rb = bullet.GetComponent<Rigidbody2D>();

            // The force of fire is given with Impulse mode
            rb.AddForce(firePointSx.up * leftWpn.bulletForce, ForceMode2D.Impulse);
        }

        if (wpn == 2)
        {
            // the bullet's position and rotation is defined by the firePoint object
            bullet = Instantiate(bulletPrefab, firePointDx.position, firePointDx.rotation);
            rb = bullet.GetComponent<Rigidbody2D>();

            // The force of fire is given with Impulse mode
            rb.AddForce(firePointDx.up * rightWpn.bulletForce, ForceMode2D.Impulse);
        }
    }
}
