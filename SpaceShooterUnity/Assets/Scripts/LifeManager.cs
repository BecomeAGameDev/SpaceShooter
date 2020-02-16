using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    
    
    // TO-DO:
    // gameOverScreen object
    // gameOverScreen scene
    private GameObject thePlayer;

    public GameObject gameOverScreen; //non c'è un metodo come FindObjectOfType? quello funziona per scripts ma per GameObject in the Scene..
    public string mainMenu= "TitleMenu";
    public float waitAfterGameOver=5f;

    //public int startingLives; spostato in MainMenu, si chiama playerLives ma concetto e' startingLives
    private int lifeCounter=3;
    private Text thisText;


    void Start()
    {
        thePlayer = GameObject.FindWithTag("Player");
        thisText = GetComponent<Text>();
        //lifeCounter = startingLives;
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
        //ma la prima volta quanto vale? dove lo setto?
        //quando una scena viene caricata
        //quando passo per main menu salvo le vite, ma altrimenti? lo fa ogni volta che viene modificato lives (e.g. GiveLife) 
        //ma allora cosa serve avere una var copia di PlayerPrefs? non posso usarla direttamente a quanto pare, devo metterla in una var

    }

    void Update()
    {
        if (lifeCounter < 0)
        {
            gameOverScreen.SetActive(true);
            thePlayer.gameObject.SetActive(false);
        }

        if (gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }
        if (waitAfterGameOver<0)
        {
            SceneManager.LoadScene(mainMenu);
        }

        thisText.text = "x" + lifeCounter;

    }

    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }
    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

}
