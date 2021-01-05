using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    private PlayerActionControls playerActionControls;

    public GameData gameData;
    public InventoryObject playerInventory;
    public InventoryObject playerEquipment;
    public HealthBar healthBar;
    public Money moneyHud;

    public GameObject knight;
    public GameObject sorcerer;

    public void Awake()
    {
        playerActionControls = new PlayerActionControls();
        Load();
        SetHealthBar();
        SetPlayerCharacter();
        Debug.Log("End Loading");
    }
    public void FixedUpdate()
    {
    }
    public void Save()
    {
        gameData.Save();
        playerEquipment.Save(gameData.gameName);
        playerInventory.Save(gameData.gameName);

    }
    public void Load()
    {
        gameData.Load();
        gameData.currentHealth = gameData.health;
        SetMoneyHUD();
        playerEquipment.Load(gameData.gameName);
        playerInventory.Load(gameData.gameName);
    }

    public void DropItem(Vector3 position)
    {
        
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

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(gameData.health);
            healthBar.SetHealth(gameData.currentHealth);
        }
    }
    public void AddMoney(int amount)
    {
        gameData.money += amount;
        SetMoneyHUD();
    }
    public void SetMoneyHUD()
    {
        if (moneyHud != null)
            moneyHud.setMoney(gameData.money);
    }

    public void SetPlayerCharacter()
    {
        if (knight != null && sorcerer != null)
        {
            if (gameData.classId == 0)
            {
                Destroy(sorcerer);
            }
            else if (gameData.classId == 1)
            {
                Destroy(knight);
            }
        } else
        {
            Debug.Log("No player");
        }
    }
    public void AddXp(int amount)
    {
        gameData.currentXp += amount;
        int xpRequiredToLevelUp = (int)(gameData.level * 100 * 1.25f);
        if(gameData.currentXp >= xpRequiredToLevelUp)
        {
            //level up
            gameData.currentXp -= xpRequiredToLevelUp;
            gameData.level++;
            //increase player stats
            gameData.attack++;
            gameData.defence++;
        }
    }
}
