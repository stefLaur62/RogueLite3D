﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCam : MonoBehaviour
{
    public Camera _camera;

    private void LateUpdate()
    {
        transform.forward = _camera.transform.forward;
    }
}
