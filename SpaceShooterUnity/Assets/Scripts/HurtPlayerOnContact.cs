using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    public int damageToGive=1;
    private HealthManager theHealthManager;

    void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            theHealthManager.HurtPlayer(damageToGive);
            //other.GetComponent<AudioSource>().Play();

            
            //to-do: for knockback I can disable collider for a while (visual effect when knocking back)
            //var thePlayer = other.GetComponent<PlayerController>(); //stesso di @start FindObjectOfType
            //thePlayer.knockbackCount = thePlayer.knockbackLenght;
            //if (other.transform.position.x < transform.position.x)
            //    thePlayer.knockFromRight = true;
            //else
            //    thePlayer.knockFromRight = false;
        }
    }
}
