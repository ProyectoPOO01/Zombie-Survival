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

    public GameObject playerGO;

    NavMeshAgent agent;
    void Start ()
    {
        playerHealth = playerGO.GetComponent<PlayerHealth>();
        enemyScript = GetComponent<EnemyScript>();
        enemyAttack = GetComponent<EnemyAttack>();

        agent = GetComponent<NavMeshAgent>();

        target = playerGO.transform;
    }
	
	void Update ()
    {
        Follow();
    }

    void Follow()
    {
        if (playerHealth.CurrentHealth > 0 && !enemyScript.PlayerInRange && !enemyAttack.IsAttacking)
        {
            agent.SetDestination(target.position);
            agent.isStopped = false;
        }
        if (playerHealth.CurrentHealth > 0 && enemyScript.PlayerInRange && enemyAttack.IsAttacking)
        {
            agent.isStopped = true;
        }
    }
}
