using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField]
    private DataManager dataManager;
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
            dataManager.AddMoney(amount);
            Destroy(this.gameObject);
        }
    }
}
