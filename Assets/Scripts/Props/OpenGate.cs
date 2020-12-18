using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    [SerializeField]
    private float speed=0.6f;

    private Vector3 openPos;
    private Vector3 closePos;

    public Transform player;
    void Start()
    {
        closePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        openPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        openPos += new Vector3(0,2,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist <= 4f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, openPos, step);
        } 
        else if (dist > 4f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, closePos, step);
        }
    }
}
