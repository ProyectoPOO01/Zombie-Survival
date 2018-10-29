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

    Animator anim;

    GameObject playerGO;

    NavMeshAgent agent;
    void Start ()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");

        playerHealth = playerGO.GetComponent<PlayerHealth>();
        enemyScript = GetComponent<EnemyScript>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHealth = GetComponent<EnemyHealth>();

        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        target = playerGO.transform;
    }

    public void Follow()
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

    public void ChangePose()
    {
        if (playerHealth.CurrentHealth > 0 && !enemyScript.PlayerInRange && !enemyHealth.IsDead)
        {
            anim.SetBool("PlayerAlive", true);
            anim.SetBool("Walk", true);
            anim.SetBool("PlayerInRange", false);
        }
        if (playerHealth.CurrentHealth > 0 && enemyScript.PlayerInRange && !enemyAttack.IsAttacking && !enemyHealth.IsDead)
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
}
