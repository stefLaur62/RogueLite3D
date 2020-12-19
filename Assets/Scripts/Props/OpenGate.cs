using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    [SerializeField]
    private float speed=0.6f;
    [SerializeField]
    private float distToPlayer = 8f;
    private Vector3 openPos;
    private Vector3 closePos;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        closePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        openPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        openPos += new Vector3(0,2,0);
        if (audioSource == null)
        {
            Debug.LogError("No gate Audio Source");
        } 
        else
        {
            audioSource.time = audioSource.clip.length * .5f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist <= distToPlayer)
        {
            if (transform.position == closePos)
                audioSource.Play();
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, openPos, step);
        } 
        else if (dist > distToPlayer)
        {
            if (transform.position == openPos)
                audioSource.Stop();
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, closePos, step);
        }
        if (audioSource.time > 16.6f)
            audioSource.Stop();
    }
}
