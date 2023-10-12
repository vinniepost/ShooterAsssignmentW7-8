using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float boostSpeed = 2f;
    public float maxSpeed = 20f;
    public float rotationSpeed = 150f;
    public float rollSpeed = 100f;
    public float rollAngle = 45f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Handle speed adjustment
        if (Input.GetKey(KeyCode.W) && baseSpeed < maxSpeed)
        {
            baseSpeed += 0.05f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            baseSpeed -= 0.10f;
        }

        baseSpeed = Mathf.Clamp(baseSpeed, 0f, maxSpeed);

        // Calculate movement direction
        Vector3 moveDirection = transform.forward * baseSpeed;
        moveDirection += transform.right * Input.GetAxis("Horizontal") * baseSpeed;

        // Apply movement force
        rb.velocity = moveDirection;

        // Handle rotation based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculate rotation based on mouse input
        Quaternion yawRotation = Quaternion.Euler(0f, mouseX, 0f);
        Quaternion pitchRotation = Quaternion.Euler(-mouseY, 0f, 0f);
        Quaternion targetRotation = transform.rotation * yawRotation * pitchRotation;

        // Smoothly interpolate current rotation to the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Handle rolling with A and D keys
        float rollInput = -Input.GetAxis("Horizontal");
        float targetRollAngle = Mathf.Clamp(rollInput * rollAngle, -rollAngle, rollAngle);
        Quaternion targetRollRotation = Quaternion.Euler(0f, 0f, targetRollAngle);

        // Smoothly interpolate current rotation to the target roll rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * targetRollRotation, Time.deltaTime * rollSpeed);

        // Unlock cursor when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
