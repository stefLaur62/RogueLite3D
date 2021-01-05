using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{

    private Animator animator;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip deathClip;
    [SerializeField]
    private GameData gameData;
    [SerializeField]
    private GameObject deathHUD;
    [SerializeField]
    private AudioSource backgroundAudioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetAnimator();
    }
    public void PlayerIsDead()
    {
        //Reset player to village
        //PauseGame
        animator.SetTrigger("Death");
        deathHUD.SetActive(true);
        Time.timeScale = 0;
        SetCursor();
        backgroundAudioSource.Stop();
        audioSource.PlayOneShot(deathClip);
    }
    private void SetAnimator()
    {
        animator = GetComponentsInChildren<Animator>()[gameData.classId];
    }

    private void SetCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

}
