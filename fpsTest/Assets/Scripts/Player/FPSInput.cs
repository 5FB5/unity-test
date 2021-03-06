using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]

[AddComponentMenu("Control/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float walkSpeed = 15.0f;
    public Camera playerCamera;

    private CharacterController ptr_characterController;
    
    private float gravity = -9.8f;
    
    private float playerCameraDefaultFOV = 60.0f;
    private float playerCameraTargetFOV = 0.0f;
    private float playerCameraFOVChangeSpeed = 25.0f;

    private void Start()
    {
        ptr_characterController = GetComponent<CharacterController>();
        Rigidbody rb = GetComponent<Rigidbody>();

        playerCamera.fieldOfView = playerCameraDefaultFOV;
        playerCameraTargetFOV = playerCamera.fieldOfView;
        
        if (rb != null)
        {
            rb.freezeRotation = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerCameraTargetFOV = playerCameraTargetFOV + 15;
            walkSpeed = walkSpeed + .5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerCameraTargetFOV = playerCameraDefaultFOV;
            walkSpeed = walkSpeed - .5f;
        }

        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, playerCameraTargetFOV, playerCameraFOVChangeSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * walkSpeed;
        float moveZ = Input.GetAxis("Vertical") * walkSpeed;

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        movement = Vector3.ClampMagnitude(movement, walkSpeed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        movement.y = gravity;

        ptr_characterController.Move(movement);
    }

}
