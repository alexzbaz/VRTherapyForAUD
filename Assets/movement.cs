using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the movement speed
    public float turnSpeed = 150f; // Adjust this value to control the turning speed
    public float gravity = 9.8f; // Adjust this value to control the strength of gravity
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input from arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Rotate the movement direction based on the player's view direction
        movement = transform.TransformDirection(movement);

        // Apply gravity
        movement.y -= gravity * Time.deltaTime;

        // Move the character using CharacterController
        characterController.Move(movement * moveSpeed * Time.deltaTime);

        // Get the mouse delta. This is not in the range -1...1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(-v, h, 0);
    }

}
