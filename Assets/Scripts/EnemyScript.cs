using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour 
{
    PlayerHealth playerHealth;
    Animator anim;

    EnemyAttack enemyAttack;

    public GameObject playerGO;

    bool playerInRange;
    public bool PlayerInRange
    {
        get { return playerInRange; }
    }

	void Start ()
    {
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
        if (playerHealth.CurrentHealth > 0 && !playerInRange )
        {
            anim.SetBool("PlayerAlive", true);
            anim.SetBool("Walk", true);
            anim.SetBool("PlayerInRange", false);
        }
        if (playerHealth.CurrentHealth > 0 && playerInRange && !enemyAttack.IsAttacking)
        {
            enemyAttack.IsAttacking = true;
            anim.SetBool("PlayerAlive", true);
            anim.SetBool("PlayerInRange", true);
            anim.SetBool("Walk", false);
            StartCoroutine(enemyAttack.AttackDelay());
        }
        if ((playerHealth.CurrentHealth == 0))
        {
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
