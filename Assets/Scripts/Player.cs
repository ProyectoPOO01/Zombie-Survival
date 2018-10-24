using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    bool reloading;
    bool shooting;
    bool aiming;

    PlayerMovement playMov;

    Animator animator;

    public bool Reloading
    {
        get { return reloading; }
    }
    public bool Shooting
    {
        get { return shooting; }
        set { shooting = value; }
    }
    public bool Aiming
    {
        get { return aiming; }
        set { aiming = value; }
    }

    void Start()
    {
        playMov = GetComponent<PlayerMovement>();


        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ChangePose();
    }

    void ChangePose()
    {
        playMov.IsWalking = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));
        shooting = Input.GetKey(KeyCode.Mouse0);
        aiming = Input.GetKey(KeyCode.Mouse1);

        if (playMov.IsWalking && !reloading)
        {
            animator.SetBool("CaminaSin", true);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", false);
            transform.Translate(transform.forward * playMov.CurrentSpeed * Time.deltaTime, Space.World);
        }
        if (playMov.IsWalking && (shooting || aiming))
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", true);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", false);
        }
        if (!playMov.IsWalking)
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
        if (playMov.IsWalking && playMov.IsRunning)
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", true);
            animator.SetBool("CorreApuntando", false);
        }
        if (playMov.IsWalking && playMov.IsRunning && (shooting || aiming))
        {
            animator.SetBool("CaminaSin", false);
            animator.SetBool("Idle", false);
            animator.SetBool("CaminaCon", false);
            animator.SetBool("CorriendoSin", false);
            animator.SetBool("CorreApuntando", true);
        }
        if (!playMov.IsWalking && Input.GetKey(KeyCode.R))
        {
            StartCoroutine(ReloadingIE());
        }
    }

    IEnumerator ReloadingIE()
    {
        reloading = true;
        animator.SetBool("IsReloading", true);
        yield return new WaitForSeconds(2.5f);
        animator.SetBool("IsReloading", false);
        reloading = false;
    }
}
