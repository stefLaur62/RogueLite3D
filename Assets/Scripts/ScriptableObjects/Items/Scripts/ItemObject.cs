using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion,
    Helmet,
    Sword,
    Staff,
    Chest,
    Shield,
    Book,
    Boots,
    Default
}
public enum Attributes
{
    Strenght,
    Stamina,
    Agility
}
public abstract class ItemObject : ScriptableObject
{
    public int id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        return new Item(this);
    }

}

[System.Serializable]
public class Item
{
    public string name;
    public int id;
    public ItemBuff[] buffs;

    public Item()
    {
        name = "";
        id = -1;
    }
    public Item(ItemObject item)
    {
        name = item.name;
        id = item.id;
        buffs = new ItemBuff[item.buffs.Length];
        for(int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max);
            buffs[i].attributes = item.buffs[i].attributes;
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attributes;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValues();
    }
    public void GenerateValues()
    {
        value = Random.Range(min, max);
    }
}