using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;
    private float volume = 1f;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    private void Step()
    {

        audioSource.PlayOneShot(getClip(),volume);
    }
    private AudioClip getClip()
    {
        if (!isGrass())
        {
            volume = 1f;
            return clips[0];
        }
        else
        {
            volume = 0.1f;
            return clips[1];
        }
    }

    private bool isGrass()
    {
        RaycastHit hit = new RaycastHit();
        Debug.DrawRay(transform.position, Vector3.down);
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "Grass")
            {
                return true;
            }

        }
        return false;
    }
}
