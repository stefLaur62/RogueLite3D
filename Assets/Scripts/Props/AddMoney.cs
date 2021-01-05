using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    private DataManager dataManager;
    private int amount;
    void Start()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();
        amount = Random.Range(3, 10);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dataManager.AddMoney(amount);
            Destroy(this.gameObject);
        }
    }
}
