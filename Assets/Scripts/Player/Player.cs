using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerActionControls playerActionControls;

    public InventoryObject inventory;
    public GameObject inventoryScreen;
    public GameObject escapeScreen;
    public GameObject PlayerStatScreen;

    public void Start()
    {
        SetCursor(false);
    }
    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            if(inventory.AddItem(new Item(item.item), 1))
                Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }

    public void Update()
    {
        if (playerActionControls.Player.OpenInventory.triggered)
        {
            inventoryScreen.SetActive(!inventoryScreen.activeSelf);
            if (inventoryScreen.activeSelf)
            {
                Time.timeScale = 0;
                SetCursor(true);
            }
            else
            {
                Time.timeScale = 1;
                SetCursor(false);
            }
        }
        if (playerActionControls.Player.Escape.triggered)
        {
            escapeScreen.SetActive(!escapeScreen.activeSelf);
            if (escapeScreen.activeSelf)
            {
                Time.timeScale = 0;
                SetCursor(true);
            }
            else
            {
                Time.timeScale = 1;
                SetCursor(false);
            }
        }
        if (playerActionControls.Player.playerStat.triggered)
        {
            PlayerStatScreen.SetActive(!PlayerStatScreen.activeSelf);
            if (PlayerStatScreen.activeSelf)
            {
                Time.timeScale = 0;
                SetCursor(true);
            }
            else
            {
                Time.timeScale = 1;
                SetCursor(false);
            }
        }
    }
    private void SetCursor(bool state)
    {
        Cursor.visible = state;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
