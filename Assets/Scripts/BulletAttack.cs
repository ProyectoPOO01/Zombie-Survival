using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    EnemyHealth enemyHealth;
    public GameObject enemy;

    public int bulletDamage;

	void Start ()
    {
        enemyHealth = enemy.GetComponent<EnemyHealth>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth.CurrentHealth -= bulletDamage;
        }
    }
}
