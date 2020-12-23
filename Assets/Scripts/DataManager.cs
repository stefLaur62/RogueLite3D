using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private PlayerActionControls playerActionControls;

    public GameData gameData;
    public InventoryObject playerInventory;
    public InventoryObject playerEquipment;
    public HealthBar healthBar;

    public void Awake()
    {
        playerActionControls = new PlayerActionControls();
        Load();
        SetHealthBar();
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
            //temporary
            if (gameData.gameName.Length < 1)
                gameData.gameName = "Caroke";
            gameData.Save();
            playerEquipment.Save(gameData.gameName);
            playerInventory.Save(gameData.gameName);
        }

    }
    public void Load()
    {
        //temporary
        if (gameData.gameName.Length < 1)
            gameData.gameName = "Caroke";
        gameData.Load();
        gameData.currentHealth = gameData.health;
        playerEquipment.Load(gameData.gameName);
        playerInventory.Load(gameData.gameName);
    }
    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }
    private void SetHealthBar()
    {
        healthBar.SetMaxHealth(gameData.health);
        healthBar.SetHealth(gameData.currentHealth);
    }
}
