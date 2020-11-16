using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ChangeKeybind : MonoBehaviour
{
    public Text _name;
    public Text keybind;
    public GameObject message;

    public ConfigManager configManager;

    private bool canChange;

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    void Start()
    {
        canChange = false;

        configManager.SetFilename("config.txt");

        configManager.Load();

        LoadKey();
    }

    private void LoadKey()
    {
        switch (_name.gameObject.name)
        {
            case "Forward":
                keybind.text = configManager.GetForward().ToString();
                break;
            case "Backward":
                keybind.text = configManager.GetBackward().ToString();
                break;
            case "Left":
                keybind.text = configManager.GetLeft().ToString();
                break;
            case "Right":
                keybind.text = configManager.GetRight().ToString();
                break;
            case "Jump":
                keybind.text = configManager.GetJump().ToString();
                break;
            case "Interact":
                keybind.text = configManager.GetInteract().ToString();
                break;
            case "Attack":
                keybind.text = configManager.GetAttack().ToString();
                break;
        }
    }

    public void changeKey()
    {
        message.SetActive(true);
        canChange = true;
        StartCoroutine("MyCoroutine");

    }
    IEnumerator MyCoroutine()
    {

        if (canChange==true)
        {

            while (!Input.anyKeyDown)
            {
                yield return null;
            }
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    Debug.Log("KeyCode down: " + keyCode);
                    message.SetActive(false);
                    canChange = false;
                    keybind.text = keyCode.ToString();
                    //change key in file
                    BindKey(keyCode);
                    configManager.Save();
                    
                    StopCoroutine("MyCoroutine");
                    break;
                }
            }
            
        }
    }

    public void BindKey(KeyCode key)
    {
        switch (_name.gameObject.name)
         {
             case "Forward":
                configManager.SetForward(key);
                break;
            case "Backward":
                configManager.SetBackward(key);
                break;
            case "Left":
                configManager.SetLeft(key);
                break;
            case "Right":
                configManager.SetRight(key);
                break;
            case "Jump":
                configManager.SetJump(key);
                break;
            case "Interact":
                configManager.SetInteract(key);
                break;
            case "Attack":
                configManager.SetAttack(key);
                break;
        }
    }
}
