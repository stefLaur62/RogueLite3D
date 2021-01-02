using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    void Start()
    {
        this.transform.Rotate(new Vector3(-90, 0, 0));
    }

    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0,0,1));
    }
}
