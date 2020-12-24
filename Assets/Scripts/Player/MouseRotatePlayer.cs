using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotatePlayer : MonoBehaviour
{
    private PlayerActionControls playerActionControls;

    [SerializeField]
    private float mouseSensitivity = 200f;
    [SerializeField]
    private Transform cameraTransform;

    void Start()
    {
#if !UNITY_EDITOR
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
    }

    void FixedUpdate()
    {

        float mouseInput = playerActionControls.Player.MouseLook.ReadValue<float>();
        if (mouseInput < -1)
            mouseInput = -1;
        else if (mouseInput > 1)
            mouseInput = 1;

        this.transform.Rotate(Vector3.up * mouseInput * mouseSensitivity * Time.fixedDeltaTime);
    }

    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }
}
