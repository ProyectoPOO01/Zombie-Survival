using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour 
{
    PlayerHealth playerHealth;

    EnemyAttack enemyAttack;
    EnemyHealth enemyHealth;
    EnemyMovement enemyMovement;

    GameObject playerGO;

    bool playerInRange;
    public bool PlayerInRange
    {
        get { return playerInRange; }
    }

	void Start ()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyMovement = GetComponent<EnemyMovement>();
        playerHealth = playerGO.GetComponent<PlayerHealth>();
	}
	
	void Update () 
    {
        Move();
        ChangeHealth();
	}

    private void Move()
    {
        enemyMovement.Follow();
        enemyMovement.ChangePose();
    }

    private void Attack()
    {
        enemyAttack.Attack();
    }

    private void ChangeHealth()
    {
        enemyHealth.ChangeHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && enemyHealth.CurrentHealth > 0)
        {
            playerInRange = true;

            bool attack = true;
            if (attack)
            {
                Attack();
                attack = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && enemyHealth.CurrentHealth > 0)
        {
            playerInRange = false;
        }
    }
}
