using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Helmet Object", menuName = "Inventory System/Items/Helmet")]
public class HelmetObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Helmet;
    }
}
