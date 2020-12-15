using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private PlayerActionControls playerActionControls;
    public GameData gameData;
    public void Awake()
    {
        playerActionControls = new PlayerActionControls();
        Load();
    }
    public void FixedUpdate()
    {
        Save();
    }
    public void Save()
    {
        float saveInput = playerActionControls.Player.SaveGame.ReadValue<float>();
        if(saveInput > 0)
        {
            gameData.Save();
        }

    }
    public void Load()
    {
        gameData.Load();
    }
    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }
}
