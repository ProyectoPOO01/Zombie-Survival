using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour 
{
    public string powerUpProperty;

    PlayerHealth playerHealth;
    WeaponShoot weaponShoot;

    GameObject shooter;
    GameObject playerGO;

    SphereCollider collider;

    private void Start()
    {
        collider = GetComponent<SphereCollider>();
        collider.enabled = false;
        shooter = GameObject.FindGameObjectWithTag("Fire");
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerGO.GetComponent<PlayerHealth>();
        weaponShoot = shooter.GetComponent<WeaponShoot>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Environment")
        {
            collider.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Environment")
        {
            collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(powerUpProperty == "Ammo")
            {
                weaponShoot.AmmoCartridge += 1;
                Destroy(this.gameObject);
            }
            else if(powerUpProperty == "Health")
            {
                if(playerHealth.CurrentHealth < 80)
                {
                    playerHealth.CurrentHealth += 20;
                }
                else
                {
                    playerHealth.CurrentHealth = 100;
                }
                
                Destroy(this.gameObject);
            }
            else
            {
                return;
            }
        }
    }
}
