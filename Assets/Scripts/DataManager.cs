using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string file = "";

    public void Awake()
    {
    }

    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    public void SetFilename(string filename)
    {
        file = filename;
    }
}
