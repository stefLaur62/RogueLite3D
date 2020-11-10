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
    public GameObject Rogue;

    private int NBCLASS = 3; 

    private GameObject[] classObject = new GameObject[3];
    private string[] classNameText = { "Knight", "Mage", "Rogue" };
    private string[] classDescriptionText = { 
        "Attaque lente et puissante\nVitesse lente\nVitalité élevée",
        "Attaque à distance\nVitesse moyenne\nVitalité faible",
        "Attaque rapide\nVitesse élévée\nVitalité moyenne" };


    // Start is called before the first frame update
    void Start()
    {
        classObject[0] = Knight;
        classObject[1] = Mage;
        classObject[2] = Rogue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLeft()
    {
        currentClassId--;
        if (currentClassId < 0)
            currentClassId = 2;
        ChangeCurrentClass();
    }

    public void ChangeRight()
    {
        currentClassId++;
        if (currentClassId > 2)
            currentClassId = 0;
        ChangeCurrentClass();
    }
    private void ChangeCurrentClass()
    {
        classTextUI.text = classNameText[currentClassId];
        activatePreview();
        classDescriptionUI.text = classDescriptionText[currentClassId];
    }
    private void activatePreview()
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
