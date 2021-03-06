﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    bool lockCursor;

    float rotationSmoothTime;
    float mouseSensitivity;
    float dstFromTarget = 2;
    float pitch;
    float yaw;

    public GameObject playerGO;
    Player player;

    public Vector2 pitchMinMax = new Vector2(-40, 85);
    Vector3 rotationSmoothVelocity;
    public Transform target;
    Vector3 currentRotation;


    void Start()
    {
        player = playerGO.GetComponent<Player>();

        lockCursor = true;

        mouseSensitivity = 10;
        dstFromTarget = 2;
        rotationSmoothTime = 0.12f;

        BloquearMouse();
    }

    void LateUpdate()
    {
        RotateCamera();
    }

    void BloquearMouse()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void RotateCamera()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation;
        
        transform.position = target.position - transform.forward * dstFromTarget;
    }
}
