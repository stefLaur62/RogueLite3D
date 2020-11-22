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
        keybinds.Load();
    }
}
