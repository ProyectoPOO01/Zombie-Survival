using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider healthSlider;

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

    public void ChangeHealth()
    {
        healthSlider.value = currentHealth;
        //Acá va el UI y se instancia en Player
    }
}
