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
    private float _lerpTime = 0.0f;

    private void Start()
    {
        ptr_characterController = GetComponent<CharacterController>();
        playerCamera.fieldOfView = playerCameraDefaultFOV;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.freezeRotation = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _lerpTime += Time.deltaTime;

        var t = _lerpTime / 3;

        t = Mathf.SmoothStep(0, 1, t);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, playerCamera.fieldOfView + 15, t);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, playerCameraDefaultFOV, t);
        }
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
