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
    Attack,
    Defence,
    Stamina,
    Damage
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