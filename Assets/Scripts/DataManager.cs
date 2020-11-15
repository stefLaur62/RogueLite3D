using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlayerData data;

    private string file = "";

    public bool Save()
    {
        string json = JsonUtility.ToJson(data);
        return writeToFile(file, json);
    }

    public void Load()
    {
        data = new PlayerData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    private bool writeToFile(string filename, string json)
    {

        string path = GetFilePath(filename);
        if (File.Exists(path)){
#if UNITY_EDITOR
            if (!EditorUtility.DisplayDialog("Sauvegarde existante", "Supprimer la précedente sauvegarde?", "Oui", "Non"))
            {
                return false;
            }
#endif
        }
        Debug.Log("Start save...");
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
        Debug.Log("Saved here:" + GetFilePath(file));
        return true;
    }

    private string ReadFromFile(string filename)
    {
        string path = GetFilePath(filename);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        } else
        {
            Debug.LogWarning("File not found");
        }
        return "";
    }

    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    public void SetFilename(string filename)
    {
        file = filename;
    }

    public void SetGameName(string name)
    {
        data.gamename = name;
    }

    public void SetClassName(string name)
    {
        data.classname = name;
    }
}
