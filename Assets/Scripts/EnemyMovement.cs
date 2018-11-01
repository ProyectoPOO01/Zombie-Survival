using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform target;

    PlayerHealth playerHealth;
    EnemyAttack enemyAttack;
    EnemyHealth enemyHealth;

    GameObject playerGO;
    Animator anim;
    NavMeshAgent agent;


    private bool playerInRange;
    public bool PlayerInRange
    {
        get { return playerInRange; }
    }
    void Start ()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        playerGO = GameObject.FindGameObjectWithTag("Player");

        playerHealth = playerGO.GetComponent<PlayerHealth>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHealth = GetComponent<EnemyHealth>();

        target = playerGO.transform;
    }

    /// <summary>
    /// Valida datos y si se cumplen, por medio de AI sigue al jugador
    /// </summary>
    public void Follow()
    {
        if (playerHealth.CurrentHealth > 0 && !playerInRange && !enemyAttack.IsAttacking && !enemyHealth.IsDead)
        {
            agent.SetDestination(target.position);
            agent.isStopped = false;
        }
        if ((playerHealth.CurrentHealth > 0 && playerInRange && enemyAttack.IsAttacking) || enemyHealth.IsDead)
        {
            agent.isStopped = true;
        }
        if (playerHealth.PlayerDead)
        {
            agent.isStopped = true;
        }
    }

    /// <summary>
    /// Valida datos y si se cumplen, se activan determinadas animaciones
    /// </summary>
    public void ChangePose()
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
        if ((playerHealth.CurrentHealth <= 0) && !enemyHealth.IsDead)
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && enemyHealth.CurrentHealth > 0)
        {
            playerInRange = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
}
