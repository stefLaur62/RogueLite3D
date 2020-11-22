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
    public Keybinds keybinds;
    private bool canChange;

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    void Start()
    {
        canChange = false;


        LoadKey();
    }

    private void LoadKey()
    {
        switch (_name.gameObject.name)
        {
            case "Forward":
                keybind.text = keybinds.forward.ToString();

                break;
            case "Backward":
                keybind.text = keybinds.backward.ToString();
                break;
            case "Left":
                keybind.text = keybinds.left.ToString();
                break;
            case "Right":
                keybind.text = keybinds.right.ToString();
                break;
            case "Jump":
                keybind.text = keybinds.jump.ToString();
                break;
            case "Interact":
                keybind.text = keybinds.interact.ToString();
                break;
            case "Attack":
                keybind.text = keybinds.attack.ToString();
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
                    message.SetActive(false);
                    canChange = false;
                    keybind.text = keyCode.ToString();
                    //change key in file
                    BindKey(keyCode);
                    StopCoroutine("MyCoroutine");
                    break;
                }
            }
            
        }
    }

    public void BindKey(KeyCode key)
    {
        keybinds.ChangeKeybind(_name.gameObject.name,key);
    }
}
