using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory container;
    public bool AddItem(Item item, int amount)
    {
        if (EmptySlotCount <= 0)
            return false;
        InventorySlot slot = FindItemOnInventory(item);
        if (!database.items[item.id].stackable || slot == null)
        {
            SetEmptySlot(item, amount);
            return true;
        }
        slot.AddAmount(amount);
        return true;
    }
    
    public int EmptySlotCount
    {
        get
        {
            int count = 0;
            for (int i = 0; i < container.items.Length; i++)
            {
                if (container.items[i].item.id <= -1)
                    count++;
            }
            return count;
        }
    }

    public InventorySlot FindItemOnInventory(Item item)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].item.id == item.id)
            {
                return container.items[i];
            }
        }
        return null;
    }

    public InventorySlot SetEmptySlot(Item item, int amount)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if(container.items[i].item.id <= -1)
            {
                container.items[i].UpdateSlot(item, amount);
                return container.items[i];
            }
        }
        //if full set up!!
        return null;
    }
    public void SwapItems(InventorySlot item1, InventorySlot item2)
    {
        if (item2.CanPlaceInSlot(item1.ItemObject) && item1.CanPlaceInSlot(item2.ItemObject))
        {
            InventorySlot tmp = new InventorySlot(item2.item, item2.amount);
            item2.UpdateSlot(item1.item, item1.amount);
            item1.UpdateSlot(tmp.item, tmp.amount);
        }
    }
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].item == item)
            {
                container.items[i].UpdateSlot(null, 0);
            }
        }
    }

    public void OnAfterDeserialize()
    {
       /* for (int i = 0; i < container.items.Count; i++)
            container.items[i].item = new Item(database.getItem[container.items[i].id]);*/
    }

    public void OnBeforeSerialize()
    {

    }

    public void Save(string gameName)
    {
        Debug.Log(string.Concat(Application.persistentDataPath, "/", gameName , savePath));
        string saveData = JsonUtility.ToJson(this, true);
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, "/", gameName, savePath));
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load(string gameName)
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, "/", gameName, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, "/", gameName, savePath),FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
        SetDatase();
    }
    public void OnEnable()
    {
        SetDatase();
    }

    public void SetDatase()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }
    public void Clear()
    {
        container.Clear();
    }
}