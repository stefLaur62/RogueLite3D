using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Staff Object", menuName = "Inventory System/Items/Staff")]
public class StaffObject : ItemObject
{

    public void Awake()
    {
        type = ItemType.Staff;
    }
}
