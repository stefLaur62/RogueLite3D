using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewScene : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private DataManager dataManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (SceneManager.GetSceneByName(sceneName).name == null)
            {
                dataManager.Save();
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }
    }
}
