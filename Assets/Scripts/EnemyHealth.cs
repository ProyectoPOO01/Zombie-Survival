using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    int currentHealth;

    bool isDead;
    public bool IsDead
    {
        get { return isDead; }
    }
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    void Start ()
    {
        isDead = false;
        startingHealth = 100;
        currentHealth = 100;
	}
	
	void Update ()
    {
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }
	}
}
