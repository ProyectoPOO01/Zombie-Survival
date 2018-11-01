using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
        Shoot();
        playerHealth.ChangeHealth();
    }

    private void Move()
    {
        playerMovement.Move();
        playerMovement.ChangePose();
    }

    private void Shoot()
    {
        weaponShoot.Shoot();
    }

    public IEnumerator ReloadingIE()
    {
        reloading = true;
        weaponShoot.Ammo = weaponShoot.MaxAmmo;
        weaponShoot.AmmoCartridge -= 1;
        anim.SetBool("IsReloading", true);
        yield return new WaitForSeconds(2.5f);
        anim.SetBool("IsReloading", false);
        reloading = false;
    }

}
