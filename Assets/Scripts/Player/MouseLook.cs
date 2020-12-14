using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private PlayerActionControls playerActionControls;

    [SerializeField]
    private float mouseSensitivity = 200f;

    public Transform playerBody;

    void Start()
    {

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float mouseInput = playerActionControls.Player.MouseLook.ReadValue<float>();
        if (mouseInput < -1)
            mouseInput = -1;
        else if (mouseInput > 1)
            mouseInput = 1;
        playerBody.Rotate(Vector3.up * mouseInput * mouseSensitivity * Time.fixedDeltaTime);
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
