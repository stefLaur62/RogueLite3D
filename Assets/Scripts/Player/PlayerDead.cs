using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip deathClip;
    public void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    public void PlayerIsDead()
    {
        //Deadth Animation
        //DeathHUD
        //Reset player to village
        //Play clip
    }
}
