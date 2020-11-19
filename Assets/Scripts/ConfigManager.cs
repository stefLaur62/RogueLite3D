using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public Keybinds keybinds;

    void Awake()
    {
        /*if (!File.Exists(GetFilePath(file)))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Config/");
            File.Create(GetFilePath(file));
        }
        Load();*/
        keybinds.Load();
    }

/*   

    public bool Save()
    {
        string json = JsonUtility.ToJson(data);
        return writeToFile(file, json);

    }

    public void Load()
    {
        data = new ParameterData();
        //Check if exist or not
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    private bool writeToFile(string filename, string json)
    {

        string path = GetFilePath(filename);

        Debug.Log("Start saving config...");
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
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
        }
        else
        {
            Debug.LogWarning("File not found");
        }
        return "";
    }

    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + "/Config/" + filename;
    }

    public void SetFilename(string filename)
    {
        file = filename;
    }*/
}
