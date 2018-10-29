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
    WeaponShoot weaponShoot;

    Animator animator;

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
        weaponShoot = player.shooter.GetComponent<WeaponShoot>();

        cameraT = Camera.main.transform;

        animator = GetComponent<Animator>();

        walkSpeed = 2;
        runSpeed = 6;
        turnSmoothTime = 0.2f;
        turnSmoothVelocity = 0;
        speedSmoothTime = 0.1f;
        speedSmoothVelocity = 0;
        currentSpeed = 0;
    }

    public void Move()
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

    public void ChangePose()
    {
        isWalking = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));
        player.Shooting = Input.GetKey(KeyCode.Mouse0);
        player.Aiming = Input.GetKey(KeyCode.Mouse1);

        if (isWalking && !player.Reloading)
        {
            animator.SetBool("CaminaSin", true);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", false);
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        }
        if (isWalking && (player.Shooting || player.Aiming))
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", true);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", false);
        }
        if (!isWalking)
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", true);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", true);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", false);
        }
        if (isWalking && IsRunning)
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", true);
            animator.SetBool("CorreApuntando", false);
        }
        if (isWalking && IsRunning && (player.Shooting || player.Aiming))
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", true);
        }
        if (!isWalking && Input.GetKey(KeyCode.R) && weaponShoot.ValidateAmmoCartridge(weaponShoot.AmmoCartridge) && !player.Reloading)
        {
            StartCoroutine(player.ReloadingIE());
        }
    }
}
