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
    public Money moneyHud;

    public GameObject knight;
    public GameObject sorcerer;

    public FollowCamera followCamera;
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
        //Save();
    }
    public void Save()
    {
        float saveInput = playerActionControls.Player.SaveGame.ReadValue<float>();
        if(saveInput > 0)
        {
            //temporary
            /*if (gameData.gameName.Length < 1)
                gameData.gameName = "Caroke";*/
            gameData.Save();
            playerEquipment.Save(gameData.gameName);
            playerInventory.Save(gameData.gameName);
        }

    }
    public void Load()
    {
        //temporary
        /*if (gameData.gameName.Length < 1)
            gameData.gameName = "Caroke";*/
        gameData.Load();
        gameData.currentHealth = gameData.health;
        SetMoneyHUD();
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
}
