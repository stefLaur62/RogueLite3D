using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chest Object", menuName = "Inventory System/Items/Chest")]
public class ChestObject : ItemObject
{

    public void Awake()
    {
        type = ItemType.Chest;
    }
}
