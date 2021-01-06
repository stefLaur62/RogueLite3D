using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextStats : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;
    [SerializeField]
    private Font font;

    public void LoadStats()
    {
        createGameObject("Attaque: ", gameData.attack);
        createGameObject("Defense: ", gameData.defence);
        createGameObject("Santé: ", gameData.health);
        createGameObject("Argent: ", gameData.money);
        createGameObject("Niveau: ", gameData.level);
        createGameObject("Xp actuel: ", gameData.currentXp);
    }

    private void createGameObject(string name, int value)
    {
        GameObject newGO = new GameObject("Stats");
        newGO.transform.SetParent(this.transform);

        Text myText = newGO.AddComponent<Text>();
        myText.text = name + value;
        myText.font = font;
        myText.fontSize = 30;
        newGO.transform.SetParent(gameObject.transform);
    }

    void OnEnable()
    {
        LoadStats();
    }
    void OnDisable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
