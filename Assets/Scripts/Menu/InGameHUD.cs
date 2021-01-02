using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        this.gameObject.SetActive(false);
    }
    public void Options()
    {
        Debug.Log("TODO");
    }
    public void Respawn()
    {
        SceneManager.LoadScene("Village");
    }
}
