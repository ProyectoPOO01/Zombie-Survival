using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour 
{
    PlayerHealth playerHealth;
    Animator anim;

    EnemyAttack enemyAttack;
    EnemyHealth enemyHealth;

    public GameObject playerGO;

    bool playerInRange;
    public bool PlayerInRange
    {
        get { return playerInRange; }
    }

	void Start ()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAttack = GetComponent<EnemyAttack>();
        playerHealth = playerGO.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
	}
	
	void Update () 
    {
        ChangePose();
	}

    void ChangePose()
    {
        if (playerHealth.CurrentHealth > 0 && !playerInRange && !enemyHealth.IsDead)
        {
            anim.SetBool("PlayerAlive", true);
            anim.SetBool("Walk", true);
            anim.SetBool("PlayerInRange", false);
        }
        if (playerHealth.CurrentHealth > 0 && playerInRange && !enemyAttack.IsAttacking && !enemyHealth.IsDead)
        {
            enemyAttack.IsAttacking = true;
            anim.SetBool("PlayerAlive", true);
            anim.SetBool("PlayerInRange", true);
            anim.SetBool("Walk", false);
            StartCoroutine(enemyAttack.AttackDelay());
        }
        if ((playerHealth.CurrentHealth == 0) && !enemyHealth.IsDead)
        {
            anim.SetBool("PlayerAlive", false);
            anim.SetBool("Walk", false);
            anim.SetBool("PlayerInRange", false);
        }
        if (enemyHealth.IsDead)
        {
            anim.SetBool("IsDead", true);
            anim.SetBool("PlayerAlive", false);
            anim.SetBool("Walk", false);
            anim.SetBool("PlayerInRange", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = true;
            Debug.Log("En rango");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
            Debug.Log("Fuera de rango");
        }
    }
}
