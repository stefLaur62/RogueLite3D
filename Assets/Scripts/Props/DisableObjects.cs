using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(!objects[i].activeSelf);
            }
        }
    }
}
