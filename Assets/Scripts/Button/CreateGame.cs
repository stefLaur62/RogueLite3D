using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateGame : MonoBehaviour
{
    public Text classname;
    public Text gamename;

    public DataManager dataManager;
    void Start()
    {
        dataManager.Load();
    }

    public void createGame()
    {
        if (gamename.text.Length > 0)
        {

            dataManager.SetFilename(gamename.text + ".txt");
            dataManager.SetClassName(classname.text);
            dataManager.SetGameName(gamename.text);

            PlayerPrefs.SetString("gamename", gamename.text);

            if (dataManager.Save())
            {
                SceneManager.LoadScene("Spawn", LoadSceneMode.Single);
            }
        }
    }

}
