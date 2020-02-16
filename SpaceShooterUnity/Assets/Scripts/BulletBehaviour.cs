using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // instantiating a BulletClass variable
    public BulletClass bullet = new BulletClass();

    float timeZero;


    // Creating a class for bullets properties
    public class BulletClass
    {
        // bullet damage
        private int _damage = 1;
        public int damage { get { return _damage; } set { _damage = value; } }

        // bullet lifetime (seconds it stays on screen)
        private float _lifeTime = .5f;
        public float lifeTime { get { return _lifeTime; } set { _lifeTime = value; } }
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Saving the time when the script starts
        timeZero = Time.time;

    }

    // OnCollisionEnter2s is called every time two rigidbodies2D collide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect; Da aggiungere quando avremo effetti esplosione proiettile

        //effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Destrying the bullet if it has exceeded its lifetime
        if (Time.time > timeZero + bullet.lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
