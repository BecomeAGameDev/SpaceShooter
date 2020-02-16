using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public string levelSelect;

    public int playerLives = 3;
    public int playerHealth = 2;

    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives); //crea un folder? dove?
        PlayerPrefs.SetInt("PlayerCurrentScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(startLevel);
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("PlayerCurrentScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
