using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSInput : MonoBehaviour
{
    public float playerWalkSpeed = 15.0f;
    public Camera playerCamera;

    private CharacterController ptr_characterController;
    private float gravity = -9.8f;
    void Start()
    {
        ptr_characterController = GetComponent<CharacterController>();
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null) {
            rb.freezeRotation = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        
    }
}
