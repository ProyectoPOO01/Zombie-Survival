using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacterController
{

    bool reloading;
    bool shooting;
    bool aiming;

    public GameObject shooter;

    WeaponShoot weaponShoot;
    PlayerMovement playerMovement;
    PlayerHealth playerHealth;

    Animator anim;

    public bool Reloading
    {
        get { return reloading; }
        set { reloading = value; }
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
        playerHealth = GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        weaponShoot = shooter.GetComponent<WeaponShoot>();
    }

    void Update()
    {
        Move();
        Attack();
        ChangeHealth();
    }

    public void Move()
    {
        if (!playerHealth.PlayerDead)
        {
            playerMovement.Move();
        }
        playerMovement.ChangePose();
    }

    public  void Attack()
    {
        weaponShoot.Shoot();
    }

    public  void ChangeHealth()
    {
        playerHealth.ChangeHealth();
    }


}
