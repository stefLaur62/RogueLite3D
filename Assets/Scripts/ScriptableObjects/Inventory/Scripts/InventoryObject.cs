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
    public void AddItem(Item item, int amount)
    {
        if (item.buffs.Length > 0)
        {
            SetEmptySlot(item, amount);
            return;
        }
        for(int i = 0; i < container.items.Length; i++)
        {
            if(container.items[i].id == item.id)
            {
                container.items[i].AddAmount(amount);
                return;
            }
        }
        SetEmptySlot(item, amount);
    }

    public InventorySlot SetEmptySlot(Item item, int amount)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if(container.items[i].id <= -1)
            {
                container.items[i].UpdateSlot(item.id, item, amount);
                return container.items[i];
            }
        }
        //if full set up!!
        return null;
    }
    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot tmp = new InventorySlot(item2.id, item2.item, item2.amount);
        item2.UpdateSlot(item1.id, item1.item, item1.amount);
        item1.UpdateSlot(tmp.id, tmp.item, tmp.amount);
    }
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].item == item)
            {
                container.items[i].UpdateSlot(-1, null, 0);
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

    public void Save()
    {
        Debug.Log(string.Concat(Application.persistentDataPath, savePath));
        string saveData = JsonUtility.ToJson(this, true);
        FileStream file = File.Create(string.Concat(Application.persistentDataPath,savePath));
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath),FileMode.Open);
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

[System.Serializable]
public class Inventory
{
    public InventorySlot[] items = new InventorySlot[30];
    public void Clear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].UpdateSlot(-1, new Item(), 0);
        }
    }
}

