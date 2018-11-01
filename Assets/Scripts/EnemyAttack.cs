using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    GameObject playerGO;

    [SerializeField]private float attackTime;
    [SerializeField]private int damage;

    public float AttackTime
    {
        get { return attackTime; }
        set { attackTime = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

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
            playerHealth.CurrentHealth -= damage;
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
        yield return new WaitForSeconds(attackTime);
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