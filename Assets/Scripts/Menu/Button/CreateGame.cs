﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateGame : MonoBehaviour
{
    public Text classname;
    public Text gamename;

    public GameData gameData;
    void Start()
    {

    }

    public void createGame()
    {
        if (gamename.text.Length > 0)
        {
            //TODO: reset all player stats
            gameData.money = 0;
            gameData.gameName = gamename.text;
            gameData.SetClass(classname.text);
            gameData.Save();
            SceneManager.LoadScene("Village", LoadSceneMode.Single);
        } 
        else
        {
            //can't create if no game name
        }
    }
}
