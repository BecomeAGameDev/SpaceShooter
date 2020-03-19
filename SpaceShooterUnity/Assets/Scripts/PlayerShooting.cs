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

    class weapon
    {
        public int fireRate;
        public int shootImpulse;
        public float lifeTime;

        public int baseDmg;
        public int shieldDmg;

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
        // TODO: sarebbe bello spostare questi in una funzione che si attivi solo se cambiano
        leftWpn.fireRate = GetComponent<WpnStats>().leftWpnStats.fireRate;
        rightWpn.fireRate = GetComponent<WpnStats>().rightWpnStats.fireRate;

        leftWpn.shootImpulse = GetComponent<WpnStats>().leftWpnStats.shootImpulse;
        rightWpn.shootImpulse = GetComponent<WpnStats>().rightWpnStats.shootImpulse;

        leftWpn.lifeTime = GetComponent<WpnStats>().leftWpnStats.lifeTime;
        rightWpn.lifeTime = GetComponent<WpnStats>().rightWpnStats.lifeTime;

        leftWpn.baseDmg = GetComponent<WpnStats>().leftWpnDmg.baseDmg;
        rightWpn.baseDmg = GetComponent<WpnStats>().rightWpnDmg.baseDmg;

        leftWpn.shieldDmg = GetComponent<WpnStats>().leftWpnDmg.shieldDmg;
        rightWpn.shieldDmg = GetComponent<WpnStats>().rightWpnDmg.shieldDmg;

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
            //TODO: prova con velocità invece che forza, così puoi sommare la velocità del player al proiettile 
            rb.AddForce(firePointSx.up * leftWpn.shootImpulse, ForceMode2D.Impulse);

            // set bullet properties
            bullet.GetComponent<BulletBehaviour>().bulletStats.lifeTime = leftWpn.lifeTime;
            bullet.GetComponent<BulletBehaviour>().bulletStats.baseDmg = leftWpn.baseDmg;
            bullet.GetComponent<BulletBehaviour>().bulletStats.shieldDmg = leftWpn.shieldDmg;

        }

        if (wpn == 2)
        {
            // the bullet's position and rotation is defined by the firePoint object
            bullet = Instantiate(bulletPrefab, firePointDx.position, firePointDx.rotation);
            rb = bullet.GetComponent<Rigidbody2D>();

            // The force of fire is given with Impulse mode
            rb.AddForce(firePointDx.up * rightWpn.shootImpulse, ForceMode2D.Impulse);

            // set bullet properties
            bullet.GetComponent<BulletBehaviour>().bulletStats.lifeTime = rightWpn.lifeTime;
            bullet.GetComponent<BulletBehaviour>().bulletStats.baseDmg = rightWpn.baseDmg;
            bullet.GetComponent<BulletBehaviour>().bulletStats.shieldDmg = rightWpn.shieldDmg;
        }
    }
}