using UnityEngine;

public class PS1Movement: MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float mouseSensitivity = 2f;
    private Rigidbody rb;
    private Transform cam;
    private float verticalRotation = 0f;

    void Start()
    {
        Application.targetFrameRate = 25;
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        rb.freezeRotation = true;
        rb.useGravity = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        cam.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 targetVelocity = (transform.right * x + transform.forward * z).normalized * walkSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }
}