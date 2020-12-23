using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;
    private int amount;
    void Start()
    {
        amount = Random.Range(3, 10);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameData.money += amount;
            Destroy(this.gameObject);
        }
    }
}
