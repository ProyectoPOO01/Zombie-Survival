using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    void Start ()
    {
        startingHealth = 100;
        currentHealth = startingHealth;
	}
	
	void Update ()
    {
        Debug.Log(currentHealth);
	}
}
