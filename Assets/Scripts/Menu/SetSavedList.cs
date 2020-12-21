using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetSavedList : MonoBehaviour
{
    [SerializeField]
    private GameObject gameNamePrefab;
    void Start()
    {
        foreach (var d in Directory.GetDirectories(string.Concat(Application.persistentDataPath)))
        {
            var dir = new DirectoryInfo(d);
            gameNamePrefab.GetComponentInChildren<Text>().text = dir.Name;
            var obj = Instantiate(gameNamePrefab, Vector3.zero, Quaternion.identity, transform);
        }
    }

    void Update()
    {
        
    }
}
