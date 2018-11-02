using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider healthSlider;

    PlayerMovement playerMovement;

    private bool playerDead;

    public int startingHealth;
    int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public bool PlayerDead
    {
        get { return playerDead; }
    }
    
    void Start ()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerDead = false;
        startingHealth = 100;
        currentHealth = startingHealth;
    }

    public void ChangeHealth()
    {
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            playerDead = true;
            playerMovement.enabled = false;
        }
        else
        {
            playerDead = false;
        }
    }
}
