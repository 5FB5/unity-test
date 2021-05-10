using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 0,
        MouseY = 1
    }

    public RotationAxis axis = RotationAxis.MouseX;
    
    public float sensivityH = 150.0f;
    public float sensivityV = 6.0f;

    public float minAngle = -90.0f;
    public float maxAngle = 90.0f;

    private float m_rotationX = 0.0f;
    private float m_rotationY = 0.0f;

    void Update()
    {
        if (axis == RotationAxis.MouseX)
        {
            m_rotationY = (Input.GetAxis("Mouse X") * sensivityH) * Time.deltaTime; // 'cause we must rotate Y axis of player for horizontal
            transform.Rotate(0, m_rotationY, 0);
        }
        else if (axis == RotationAxis.MouseY)
        {
            m_rotationX -= (Input.GetAxis("Mouse Y") * sensivityV) * Time.deltaTime; // 'cause we must rotate X axis of camera for vertical
            m_rotationX = Mathf.Clamp(m_rotationX, minAngle, maxAngle);
 
            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(m_rotationX, rotationY, 0);
        }
    }
}
