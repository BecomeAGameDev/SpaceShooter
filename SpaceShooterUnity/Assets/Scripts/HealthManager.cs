using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //playerHealth = maxPlayerHealth;
    public bool isDead=false;
    public int maxPlayerHealth; //maxPlayerHealth=3 > substituted in PlayerPrefs, originated in MainMenu
    public int playerHealth;


    Text thisText;
    //playerHealth = maxPlayerHealth;
    private LevelManager theLevelManager;
    private LifeManager theLifeManager;


    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        theLifeManager = FindObjectOfType<LifeManager>();
        thisText = GetComponent<Text>();
        playerHealth =PlayerPrefs.GetInt("PlayerCurrentHealth"); //playerHealth = maxPlayerHealth;
    }


    void Update()
    {
        
        if (playerHealth <=0 && !isDead)
        { 
            theLevelManager.RespawnPlayer();
            isDead = true; //cosi respawna 1 sola volta
            theLifeManager.TakeLife();
        }
        thisText.text = "Health: " + playerHealth;

    }
    public void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
    }
    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
    }
}
