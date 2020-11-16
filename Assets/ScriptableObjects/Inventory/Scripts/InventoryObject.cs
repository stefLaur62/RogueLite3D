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
    public void AddItem(Item _item, int _amount)
    {

        if (_item.buffs.Length > 0)
        {
            container.items.Add(new InventorySlot(_item.id, _item, _amount));
            return;
        }
        for(int i = 0; i < container.items.Count; i++)
        {
            if(container.items[i].item.id == _item.id)
            {
                container.items[i].AddAmount(_amount);
                return;
            }
        }
        container.items.Add(new InventorySlot(_item.id, _item, _amount));
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < container.items.Count; i++)
            container.items[i].item = new Item(database.getItem[container.items[i].id]);
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
}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> items = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    public int id;
    public Item item;
    public int amount;

    public InventorySlot(int _id,Item _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }
}