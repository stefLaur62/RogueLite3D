using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sword Object", menuName = "Inventory System/Items/Sword")]
public class SwordObject : ItemObject
{

    public void Awake()
    {
        type = ItemType.Sword;
    }
}
