using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField]private int startingHealth;
    private int currentHealth;

    public GameObject canvas;
    public Slider healthSlider;
    

    GameObject score;
    ScoreManagement scoreManagement;

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
        score = GameObject.FindGameObjectWithTag("GameController");
        scoreManagement = score.GetComponent<ScoreManagement>();

        healthSlider.maxValue = startingHealth;
        isDead = false;
        currentHealth = startingHealth;
	}
	
	public void ChangeHealth()
    {
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !ValidateDeath(isDead))
        {
            canvas.SetActive(false);
            isDead = true;
            scoreManagement.CanIncreaseScore = true;
        }
	}

    private bool ValidateDeath(bool dead)
    {
        if(dead)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
