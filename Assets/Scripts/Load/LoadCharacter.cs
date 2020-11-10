using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharacter : MonoBehaviour
{
    public DataManager dataManager;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public Sprite[] spriteArray;
    public RuntimeAnimatorController[] controllerArray;

    private string classname;
    private int idClass;
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetString("gamename"));
        dataManager.SetFilename(PlayerPrefs.GetString("gamename") + ".txt");

        //Debug.Log(PlayerPrefs.GetString("gamename") + ".txt");
        dataManager.Load();
        classname = dataManager.data.classname;
        //set image + animator
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        Debug.Log("Class:" + classname);

        switch (classname)
        {
            case "Knight":
                idClass = 0;
                break;
            case "Mage":
                idClass = 1;
                break;
            case "Rogue":
                idClass = 2;
                break;
        }
        spriteRenderer.sprite = spriteArray[idClass];
        animator.runtimeAnimatorController = controllerArray[idClass];
    }

    void Update()
    {
        
    }
}
