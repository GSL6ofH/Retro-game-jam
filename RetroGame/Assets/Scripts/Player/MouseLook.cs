using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody;
    private float verticalRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        playerBody.Rotate(Vector3.up * mouseX);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        float snappedY = Mathf.Round(verticalRotation / 2f) * 2f;
        transform.localRotation = Quaternion.Euler(snappedY, 0, 0);
    }
}
