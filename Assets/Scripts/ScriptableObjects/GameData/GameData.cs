using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    public string gameName = "";
    public string savePath = "/GameData.save";
    public int classId;
    public int money = 0;
    public int force = 0;
    public int speed = 0;
    public int health = 0;

    public void Save()
    {
        if (!Directory.Exists(string.Concat(Application.persistentDataPath, gameName)))
            Directory.CreateDirectory(string.Concat(Application.persistentDataPath, "/", gameName));
        if (gameName.Length < 1)
        {
            Debug.LogError("Can't save: No GameName found!");
        }
        else
        {
            string saveData = JsonUtility.ToJson(this, true);
            FileStream file = File.Create(string.Concat(Application.persistentDataPath, "/", gameName, savePath));
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
            file.Close();
        }
    }

    public void Load()
    {
        if (gameName.Length > 0)
        {
            if(!Directory.Exists(string.Concat(Application.persistentDataPath, gameName)))
            {
                Directory.CreateDirectory(string.Concat(Application.persistentDataPath, "/", gameName));
            }
            if(File.Exists(string.Concat(Application.persistentDataPath, "/", gameName, savePath)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath, "/", gameName, savePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
                file.Close();
            } else
            {
                Debug.LogError("File error: file not found can't load");
            }
        }
        else
        {
            Debug.LogError("Error: No game Name!");
        }

    }
    public void SetClass(string text)
    {
        switch (text)
        {
            case "Guerrier":
                classId = 0;
                health = 200;
                break;
            case "Mage":
                classId = 1;
                health = 100;
                break;
            default:
                classId = 0;
                break;
        }
    }
}
