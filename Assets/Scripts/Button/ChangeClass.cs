using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeClass : MonoBehaviour
{
    private int currentClassId = 0;
    public Text classTextUI;
    public Text classDescriptionUI;
    public GameObject Knight;
    public GameObject Mage;

    private int NBCLASS = 2; 

    private GameObject[] classObject;
    private string[] classNameText = { "Knight", "Mage"};
    private string[] classDescriptionText = { 
        "Attaque lente et puissante\nVitalité élevée",
        "Attaque à distance\nVitalité faible"};


    // Start is called before the first frame update
    void Start()
    {
        classObject = new GameObject[NBCLASS];
        classObject[0] = Knight;
        classObject[1] = Mage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLeft()
    {
        currentClassId--;
        if (currentClassId < 0)
            currentClassId = NBCLASS-1;
        ChangeCurrentClass();
    }

    public void ChangeRight()
    {
        currentClassId++;
        if (currentClassId > NBCLASS-1)
            currentClassId = 0;
        ChangeCurrentClass();
    }
    private void ChangeCurrentClass()
    {
        classTextUI.text = classNameText[currentClassId];
        ActivatePreview();
        classDescriptionUI.text = classDescriptionText[currentClassId];
    }
    private void ActivatePreview()
    {
        for(int i = 0; i < NBCLASS; ++i)
        {
            if(i == currentClassId)
            {
                classObject[i].SetActive(true);
            } else
            {
                classObject[i].SetActive(false);
            }
        }
    }

}
