using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewScene : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    private bool isAlreadyLoaded;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject PlayerCamera;
    [SerializeField]
    private GameObject PlayerHUD;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isAlreadyLoaded)
        {
            if (SceneManager.GetSceneByName(sceneName).name == null)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
                SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(sceneName));
                SceneManager.MoveGameObjectToScene(PlayerCamera, SceneManager.GetSceneByName(sceneName));
                SceneManager.MoveGameObjectToScene(PlayerHUD, SceneManager.GetSceneByName(sceneName));
            }
        }
    }
}
