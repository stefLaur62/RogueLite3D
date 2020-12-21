using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField]
    private Text _name;
    [SerializeField]
    private GameData gameData;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Load()
    {
        gameData.gameName = _name.text;
        SceneManager.LoadScene("Village");
    }
}
