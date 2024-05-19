using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFPS : MonoBehaviour
{
    public float walkSpeed = 5f;        // Speed of walking
    public float runSpeed = 10f;        // Speed of running
    public float jumpForce = 5f;        // Force of jumping
    public Transform cameraTransform;   // Reference to the camera transform
    public float mouseSensitivity = 2f; // Mouse sensitivity for camera control
    public GameObject ilkKagit;
    public bool ilkKagitAcik;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isJumping;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Player movement
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Player jumping
        if (controller.isGrounded)
        {
            playerVelocity.y = 0f;
            isJumping = false;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
            isJumping = true;
        }

        // Apply gravity to the player
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Player camera control
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        Vector3 currentRotation = cameraTransform.rotation.eulerAngles;
        float desiredRotationX = currentRotation.x - mouseY;
        if (desiredRotationX > 180)
            desiredRotationX -= 360;
        desiredRotationX = Mathf.Clamp(desiredRotationX, -90f, 90f);
        cameraTransform.rotation = Quaternion.Euler(desiredRotationX, currentRotation.y, currentRotation.z);
        
        if (Input.GetKeyDown(KeyCode.H) && ilkKagitAcik)
        {
            ilkKagitAcik = false;
            ilkKagit.SetActive(false);
        }
    }
}
