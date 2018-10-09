using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

    float walkSpeed;
    float runSpeed;
    float turnSmoothTime;
    float speedSmoothTime;
    float currentSpeed;
    float speedSmoothVelocity;
    float turnSmoothVelocity;

    public int startingHealth;
    int currentHealth;

    bool reloading;
    bool isWalking;
    bool running;
    bool shooting;
    bool aiming;

    Animator animator;
    Transform cameraT;

    public bool IsWalking
    {
        get { return isWalking; }
    }
    public bool Reloading
    {
        get { return reloading; }
    }
    public bool Shooting
    {
        get { return shooting; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        startingHealth = 100;
        currentHealth = startingHealth;

        walkSpeed = 2;
        runSpeed = 6;
        turnSmoothTime = 0.2f;
        turnSmoothVelocity = 0;
        speedSmoothTime = 0.1f;
        speedSmoothVelocity = 0;
        currentSpeed = 0;

        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }
	
	void Update ()
    {

        currentHealth = startingHealth;
        Desplazar();
        CambiarPose();
	}


    void Desplazar()
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

        isWalking = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));
        shooting = Input.GetKey(KeyCode.Mouse0);
        aiming = Input.GetKey(KeyCode.Mouse1);

    }

    void CambiarPose()
    {
        if (isWalking && !reloading)
        {
            animator.SetBool("CaminaSin", true);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", false);
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        }
        if (isWalking && (shooting || aiming))
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
        if (isWalking && running)
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", true);
            animator.SetBool("CorreApuntando", false);
        }
        if (isWalking && running && (shooting || aiming))
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", true);
        }
        if (!isWalking && Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Recargando());
        }
    }

    IEnumerator Recargando()
    {
        reloading = true;
        animator.SetBool("IsReloading", true);
        yield return new WaitForSeconds(2.5f);
        animator.SetBool("IsReloading", false);
        reloading = false;
    }
}
