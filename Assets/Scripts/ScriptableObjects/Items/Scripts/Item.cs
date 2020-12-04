using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int id = -1;
    public ItemBuff[] buffs;

    public Item()
    {
        name = "";
        id = -1;
    }
    public Item(ItemObject item)
    {
        name = item.name;
        id = item.data.id;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max);
            buffs[i].attributes = item.data.buffs[i].attributes;
        }
    }
}
