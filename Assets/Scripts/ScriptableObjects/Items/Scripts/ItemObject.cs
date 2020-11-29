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
    public Sprite uiDisplay;
    public bool stackable;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public Item data = new Item();

    public Item CreateItem()
    {
        return new Item(this);
    }

}

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
        for(int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max);
            buffs[i].attributes = item.data.buffs[i].attributes;
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