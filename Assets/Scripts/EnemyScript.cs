using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour, ICharacterController
{
    PlayerHealth playerHealth;

    EnemyAttack enemyAttack;
    EnemyHealth enemyHealth;
    EnemyMovement enemyMovement;

    GameObject playerGO;

    [SerializeField] private float attackTime;
    [SerializeField] private int damage;

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

    public void Move()
    {
        enemyMovement.Follow();
        enemyMovement.ChangePose();
    }

    public void Attack()
    {
        enemyAttack.Attack();
    }

    public void ChangeHealth()
    {
        enemyHealth.ChangeHealth();
    }

}
