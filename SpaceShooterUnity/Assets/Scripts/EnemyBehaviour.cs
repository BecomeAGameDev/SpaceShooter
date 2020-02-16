using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // instantiating an EnemyClass variable
    EnemyClass enemy = new EnemyClass();

    int damageTaken;

    // creating a class for enemy properties
    class EnemyClass
    {
        private int _health = 5;
        public int health { get { return _health; } set { _health = value; } }
    }

    // OnCollisionEnter2s is called every time two rigidbodies2D collide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            damageTaken = collision.gameObject.GetComponent<BulletBehaviour>().bullet.damage;
            enemy.health -= damageTaken;
        }

        if (enemy.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
