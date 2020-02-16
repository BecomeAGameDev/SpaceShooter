using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay=2f;
    public GameObject currentCheckpoint; // -------------TO-DO ---- TOP PRIORITY: make checkpoint object
    //public GameObject deathParticle; // -------------TO-DO
    //public GameObject respawnParticle; // -------------TO-DO
    
    //public int pointPenaltyOnDeath =50;
    //private ScoreManager theScoreManager;
    private HealthManager theHealthManager;
    private PlayerMovement thePlayer;
    private CinemachineVirtualCamera theCamera;
    //private float gravityStore; //disable player mov when falling off the screen

    void Start()
    {
        //theScoreManager = FindObjectOfType<ScoreManager>();
        //thePlayer = GameObject.FindWithTag("Player");
        thePlayer = FindObjectOfType<PlayerMovement>();
        theCamera = FindObjectOfType<CinemachineVirtualCamera>(); // -------------TO-DO: modify if u'r not using camera cinemachine
        theHealthManager = FindObjectOfType<HealthManager>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }
    public IEnumerator RespawnPlayerCo()
    {
        //Instantiate(deathParticle, thePlayer.transform.position, thePlayer.transform.rotation);

        thePlayer.enabled = false;
        thePlayer.GetComponent<Renderer>().enabled = false;


        //thePlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // non funziona...
        theCamera.enabled = false;

        thePlayer.tag = "PlayerIsDead"; //altriemnti ho collisioni.. trova un modo piu pulito
        yield return new WaitForSeconds(respawnDelay);
        thePlayer.tag = "Player";

        theCamera.enabled = true;
        thePlayer.transform.position = currentCheckpoint.transform.position; // -------------TO-DO

        thePlayer.enabled = true;
        thePlayer.GetComponent<Renderer>().enabled = true;

        //Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation); // -------------TO-DO

        //theScoreManager.AddPoints(-pointPenaltyOnDeath);
        theHealthManager.FullHealth();
        theHealthManager.isDead= false;

    }
}
