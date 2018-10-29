using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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

    void ChangeHealth()
    {
        //Acá va el UI y se instancia en Player
    }
}
