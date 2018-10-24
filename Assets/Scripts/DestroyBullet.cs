using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour 
{
    public float timeToDestroy;
    float timer;

    WeaponShoot weaponShoot;
    public GameObject player;

    EnemyHealth enemyHealth;
    public GameObject enemy;

    void Start()
    {
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    void Update () 
    {
        timer += Time.deltaTime;
        //Destruir();
	}

    /*void Destruir()
    {
        if(timer >= timeToDestroy)
        {
            Destroy(weaponShoot.BullReference);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth.CurrentHealth -= 5;
        }
    }
}
