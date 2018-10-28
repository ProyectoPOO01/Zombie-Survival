using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    int currentHealth;

    public GameObject canvas;
    public Slider healthSlider;

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
        healthSlider.maxValue = startingHealth;
        isDead = false;
        currentHealth = startingHealth;
	}
	
	void Update ()
    {
        healthSlider.value = currentHealth;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            canvas.SetActive(false);
            isDead = true;
        }
        else
        {
            isDead = false;
        }
	}
}
