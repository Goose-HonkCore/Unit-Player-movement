using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5.0f;
    public float acceleration = 10.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -20.0f;

    [Header("Camera Settings")]
    public float mouseSensitivity = 2.0f;
    public float upperLookLimit = 80.0f;
    public float lowerLookLimit = 80.0f;

    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector3 currentMovement;
    private float verticalVelocity;

    private float rotationX = 0;

    private bool isGrounded;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        HandleMovementInput();
        HandleMouseLook();
        ApplyMovement();
    }

    private void HandleMovementInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * moveZ + transform.right * moveX;

        if (moveDirection.magnitude > 1f)
            moveDirection.Normalize();

        currentMovement = Vector3.Lerp(currentMovement, moveDirection * moveSpeed, acceleration * Time.deltaTime);

        if (isGrounded)
        {
            verticalVelocity = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(2 * -gravity * jumpHeight);
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    private void ApplyMovement()
    {
        Vector3 movement = currentMovement;
        movement.y = verticalVelocity;

        characterController.Move(movement * Time.deltaTime);
    }
}