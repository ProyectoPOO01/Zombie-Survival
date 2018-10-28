using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    EnemyHealth enemyHealth;

    public int bulletDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.CurrentHealth -= bulletDamage;
        }
    }
}
