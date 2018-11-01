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
    
	void Start ()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyMovement = GetComponent<EnemyMovement>();

        playerGO = GameObject.FindGameObjectWithTag("Player");
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

}
