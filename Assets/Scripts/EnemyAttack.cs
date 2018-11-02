using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    EnemyScript enemyScript;

    GameObject playerGO;


    private bool canAttack; //Animation Event

    bool isAttacking;

    public bool IsAttacking
    {
        get { return isAttacking; }
        set { isAttacking = value; }
    }

	void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyScript = GetComponent<EnemyScript>();

        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerGO.GetComponent<PlayerHealth>();
        isAttacking = false;
	}

    /// <summary>
    /// Valida datos y si se cumplen, le hace daño al jugador
    /// </summary>
    public void Attack()
    {
        if (!isAttacking && canAttack)
        {
            playerHealth.CurrentHealth -= enemyScript.Damage;
            canAttack = false;
        }
    }

    /// <summary>
    /// Activa el evento de la animación
    /// </summary>
    void AttackPlayer()
    {
        canAttack = true;
    }

    /// <summary>
    /// Añade delay a los ataques
    /// </summary>
    /// <returns></returns>
    public IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(enemyScript.AttackTime);
        isAttacking = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && enemyHealth.CurrentHealth > 0)
        {
            bool attack = true;
            if (attack)
            {
                Attack();
                attack = false;
            }
        }
    }
}