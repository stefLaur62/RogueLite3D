﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryCanvas;
    public Keybinds keybinds;
    public void Start()
    {
        //inventory.Load();
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.items = new InventorySlot[30];
    }

    public void Update()
    {
        //change save / load later
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inventory.Load();
        }
        if (Input.GetKeyDown(keybinds.inventory))
        {
            inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);
        }
    }
}
