using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour 
{
    public string powerUpProperty;

    PlayerHealth playerHealth;
    WeaponShoot weaponShoot;

    public GameObject shooter;
    public GameObject playerGO;

    private void Start()
    {
        playerHealth = playerGO.GetComponent<PlayerHealth>();
        weaponShoot = shooter.GetComponent<WeaponShoot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(powerUpProperty == "Ammo")
            {
                weaponShoot.AmmoCartridge += 1;
            }
            else if(powerUpProperty == "Health")
            {
                playerHealth.CurrentHealth += 20;
            }
            else
            {
                return;
            }
        }
    }
}
