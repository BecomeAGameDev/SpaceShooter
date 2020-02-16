using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    
    
    public int damageToGive = 1;

    private HealthManager theHealthManager;
    private Rigidbody2D rb;
    
    
    void Start()
    {
        theHealthManager=FindObjectOfType<HealthManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name);
        if (other.tag == "Player")
        {
            //Instantiate(enemyDeathEffect,other.transform.position,other.transform.rotation);
            //Destroy(other.gameObject);
            //theScoreManager.AddPoints(pointsForKill);
            //Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject.gameObject);
            theHealthManager.HurtPlayer(damageToGive);
        }
        //to-do: must autodestroy when hitting colliders!=from Player
        //to-do: make a general script to destroy general object after maxTime
        
    }

}
