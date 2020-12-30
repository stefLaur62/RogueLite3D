using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stepClips;
    [SerializeField]
    private AudioClip[] jumpClips;
    [SerializeField]
    private AudioSource audioSource;
    private float volume = 1f;

    private void Step()
    {
        Debug.Log(audioSource);
        audioSource.PlayOneShot(getStepClip(),volume);
    }
    private AudioClip getStepClip()
    {
        if (!isGrass())
        {
            volume = 1f;
            return stepClips[0];
        }
        else
        {
            volume = 0.1f;
            return stepClips[1];
        }
    }

    private bool isGrass()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.tag == "Grass")
            {
                return true;
            }

        }
        return false;
    }

    private void JumpSound()
    {
        audioSource.PlayOneShot(getJumpClip(), volume);
    }

    private AudioClip getJumpClip()
    {
        if (!isGrass())
        {
            volume = .4f;
            return jumpClips[0];
        }
        else
        {
            volume = .1f;
            return jumpClips[1];
        }
    }
}
