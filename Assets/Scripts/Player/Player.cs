using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerActionControls playerActionControls;

    public InventoryObject inventory;
    public GameObject inventoryScreen;
    public void Start()
    {

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
        inventory.container.Clear();
    }

    public void Update()
    {
        float inventoryInput = playerActionControls.Player.OpenInventory.ReadValue<float>();

        if (inventoryInput > 0)
        {
            inventoryScreen.SetActive(!inventoryScreen.activeSelf);
            if (inventoryScreen.activeSelf)
            {
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
            }
        }
    }
}
