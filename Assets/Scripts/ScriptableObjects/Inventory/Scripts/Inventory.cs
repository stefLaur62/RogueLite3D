using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public InventorySlot[] items = new InventorySlot[30];
    public void Clear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].RemoveItem();
        }
    }
}
