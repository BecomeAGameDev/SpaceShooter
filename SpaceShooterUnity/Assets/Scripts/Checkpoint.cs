using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private LevelManager theLevelManager;

    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //if (theLevelManager.currentCheckpoint.transform.position!= gameObject.transform.position)
            if (!GameObject.ReferenceEquals(theLevelManager.currentCheckpoint, gameObject))
                GetComponent<AudioSource>().Play();

            theLevelManager.currentCheckpoint = gameObject;
        }
    }
}
