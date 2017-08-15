using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameStatus : MonoBehaviour {

    public GameObject endGameMenu;

    public string mainMenu;
    public string currentScene;

    private void Awake()
    {
        endGameMenu.SetActive(false);
    }

    public void endGame()
    {
        endGameMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void retryGame()
    {
        endGameMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
