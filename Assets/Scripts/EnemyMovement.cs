using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform target;

    PlayerHealth playerHealth;
    EnemyScript enemyScript;
    EnemyAttack enemyAttack;
    EnemyHealth enemyHealth;

    public GameObject playerGO;

    NavMeshAgent agent;
    void Start ()
    {
        playerHealth = playerGO.GetComponent<PlayerHealth>();
        enemyScript = GetComponent<EnemyScript>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHealth = GetComponent<EnemyHealth>();

        agent = GetComponent<NavMeshAgent>();

        target = playerGO.transform;
    }
	
	void Update ()
    {
        Follow();
    }

    void Follow()
    {
        if (playerHealth.CurrentHealth > 0 && !enemyScript.PlayerInRange && !enemyAttack.IsAttacking && !enemyHealth.IsDead)
        {
            agent.SetDestination(target.position);
            agent.isStopped = false;
        }
        if ((playerHealth.CurrentHealth > 0 && enemyScript.PlayerInRange && enemyAttack.IsAttacking) || enemyHealth.IsDead)
        {
            agent.isStopped = true;
        }
    }
}
