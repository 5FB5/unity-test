using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{
    public enum RotationAxis {
        MouseX = 0,
        MouseY = 1,
    }

    public float sensivityH = 50.0f;
    public float sensivityV = 60.0f;

    public float minAngleH = -90.0f;
    public float maxAngleH = 90.0f;
    
    private float m_rotationX = 0.0f;
    private float m_rotationY = 0.0f;

    public RotationAxis rotationAxis = RotationAxis.MouseX;

    void Update() {
        if (rotationAxis == RotationAxis.MouseX) {
            m_rotationY = Input.GetAxis("Mouse X") * sensivityH * Time.deltaTime;

            transform.Rotate(0, m_rotationY, 0);
        }
        else if (rotationAxis == RotationAxis.MouseY) {
            m_rotationX -= Input.GetAxis("Mouse Y") * sensivityV * Time.deltaTime;
            m_rotationX = Mathf.Clamp(m_rotationX, minAngleH, maxAngleH);

            float _rotationY = transform.eulerAngles.y;

            transform.localEulerAngles = new Vector3(m_rotationX, _rotationY, 0);
        }
    }
}
