using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;

    private Vector3 movement;
    private float verticalRotation = 0f;
    private bool isGrounded = false;

    void Update()
    {
        // Get input for movement
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        movement = transform.right * horizontalMovement + transform.forward * verticalMovement;

        // Get input for mouse movement
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        float verticalMouseMovement = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation -= verticalMouseMovement;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Apply rotation to player and camera
        transform.Rotate(0f, horizontalRotation, 0f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Move the player based on input
        transform.position += movement.normalized * movementSpeed * Time.deltaTime;
    }
    void OnCollisionStay(Collision collision)
    {
        // Check if the object we collided with is on the ground layer
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            // Set isGrounded to true
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        // Reset isGrounded to false when the player leaves a collision
        isGrounded = false;
    }
}
