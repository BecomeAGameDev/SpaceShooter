using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private bool playerInZone;
    public string levelToLoad;

    void Start()
    {
        playerInZone = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerInZone = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerInZone = false;
    }


    void Update()
    {
        //if (Input.GetButtonDown("Submit") && playerInZone) >> qua player deve premere "invio" per entrare nel portale e uindi nel nuovo livello 
        if (playerInZone)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        
    }
}
