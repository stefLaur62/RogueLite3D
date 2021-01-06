using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameHUD : MonoBehaviour
{

    public void LeaveGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
    public void Options()
    {

        Time.timeScale = 1;
        Debug.Log("TODO");
    }
    public void Respawn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Village");
    }
}
