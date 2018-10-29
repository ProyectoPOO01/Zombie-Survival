using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth playerHealth;
    EnemyScript enemyScript;

    [Header("GameObjects")]
    [Space(10)]
    GameObject playerGO;

    [Header("Attack Properties")]
    [Space(10)]
    public float vectorMagnitude;
    public float attackTime;
    public int damage;

    bool isAttacking;

    public bool IsAttacking
    {
        get { return isAttacking; }
        set { isAttacking = value; }
    }

	void Start ()
    {
        enemyScript = GetComponent<EnemyScript>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerGO.GetComponent<PlayerHealth>();
        isAttacking = false;
	}
	

    public void Attack()
    {
        if (!isAttacking)
        {
            playerHealth.CurrentHealth -= damage;
        }
    }

    public IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
    }
}