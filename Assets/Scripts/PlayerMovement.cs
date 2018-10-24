using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float walkSpeed;
    float runSpeed;
    float turnSmoothTime;
    float speedSmoothTime;
    float currentSpeed;
    float speedSmoothVelocity;
    float turnSmoothVelocity;

    bool isWalking;
    bool running;

    Player player;

    Camera cam;
    Transform cameraT;
    public GameObject camara;

    public float CurrentSpeed
    {
        get { return currentSpeed; }
    }
    public bool IsWalking
    {
        get { return isWalking; }
        set { isWalking = value; }
    }
    public bool IsRunning
    {
        get { return running; }
    }
    
    void Start ()
    {
        player = GetComponent<Player>();

        cam = camara.GetComponent<Camera>();

        cameraT = Camera.main.transform;

        walkSpeed = 2;
        runSpeed = 6;
        turnSmoothTime = 0.2f;
        turnSmoothVelocity = 0;
        speedSmoothTime = 0.1f;
        speedSmoothVelocity = 0;
        currentSpeed = 0;
    }
	
	void Update ()
    {
        Move();
	}

    void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
    }
}
