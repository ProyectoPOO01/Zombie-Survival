using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour {

    bool lockCursor;
    float mouseSensitivity;
    float dstFromTarget;
    float rotationSmoothTime;
    float yaw;
    float pitch;
    public ControlCamara()
    {
        lockCursor = true;
        mouseSensitivity = 10;
        dstFromTarget = 2;
        rotationSmoothTime = 0.12f;
    }

    public Transform target;
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    void Start ()
    {
        lockCursor = true;
        mouseSensitivity = 10;
        dstFromTarget = 2;
        rotationSmoothTime = 0.12f;

        BloquearMouse();
	}
	
	void LateUpdate ()
    {
        CamaraNormal();
	}

    void BloquearMouse()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void CamaraNormal()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * dstFromTarget;
    }
}
