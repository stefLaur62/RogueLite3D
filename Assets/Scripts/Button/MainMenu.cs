using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas mainMenu;
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene("CreateGame", LoadSceneMode.Additive);
    }

    public void ConfigGame()
    {
        SceneManager.LoadScene("Config", LoadSceneMode.Additive);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
