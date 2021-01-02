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

    public void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        SetAnimator();
        
    }
    public void PlayerIsDead()
    {
        //Reset player to village
        animator.SetTrigger("Death");
        deathHUD.SetActive(true);
        audioSource.PlayOneShot(deathClip);
    }
    private void SetAnimator()
    {
        animator = GetComponentsInChildren<Animator>()[gameData.classId];
    }
}
