using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemType[] allowedItems = new ItemType[0];
    public UserInterface parent;
    public int id = -1;
    public Item item;
    public int amount;

    public InventorySlot()
    {
        id = -1;
        item = null;
        amount = 0;
    }
    public InventorySlot(int _id, Item _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }

    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
    }

    public bool CanPlaceInSlot(ItemObject _item)
    {
        if (allowedItems.Length <= 0)
            return true;
        for (int i = 0; i < allowedItems.Length; i++)
        {
            if (_item.type == allowedItems[i])
                return true;

        }
        return false;
    }
}
