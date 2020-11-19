using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "New Keybinds", menuName = "Config/Keybinds List")]
public class Keybinds : ScriptableObject
{
    public string savePath = "/Keybinds.save";
    public KeyCode forward = KeyCode.Z;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.Q;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public KeyCode attack = KeyCode.Mouse0;
    public KeyCode interact = KeyCode.E;
    public KeyCode sprint = KeyCode.LeftShift;
    public KeyCode block = KeyCode.Mouse1;
    public KeyCode inventory = KeyCode.I;

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    public void ChangeKeybind(string name, KeyCode key)
    {
        switch (name)
        {
            case "Forward":
                forward = key;
                break;
            case "Backward":
                backward = key;
                break;
            case "Left":
                left = key;
                break;
            case "Right":
                right = key;
                break;
            case "Jump":
                jump = key;
                break;
            case "Interact":
                interact = key;
                break;
            case "Attack":
                attack = key;
                break;
        }
    }
}
