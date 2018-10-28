using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth playerHealth;

    [Header("GameObjects")]
    [Space(10)]
    public GameObject playerGO;
    public GameObject fist;
    public GameObject playerBody;

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
        playerHealth = playerGO.GetComponent<PlayerHealth>();
        isAttacking = false;
	}
	
	void Update ()
    {
        if (!isAttacking)
        {
            Attack();
        }
	}

    void Attack()
    {
        Vector2 distAttack = new Vector2(playerBody.transform.position.x - fist.transform.position.x, playerBody.transform.position.y - fist.transform.position.y);
        if (distAttack.magnitude <= vectorMagnitude)
        {
            playerHealth.CurrentHealth -= damage;
            Debug.Log("Atacando");
        }
    }

    public IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
    }
}