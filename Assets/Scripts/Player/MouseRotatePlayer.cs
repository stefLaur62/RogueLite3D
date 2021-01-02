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

        Vector2 mouseInput = playerActionControls.Player.MouseLook.ReadValue<Vector2>();
        this.transform.Rotate(Vector3.up * mouseInput.normalized.x * mouseSensitivity * Time.fixedDeltaTime);
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
