using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagement : MonoBehaviour 
{
    int startingScore;
    int currentScore;

    public int scoreToSpawn;

    bool canIncreaseScore;

    EnemyHealth enemyHealth;
    public GameObject enemy;

    PickUpSpawner pickUpSpawner;
    public GameObject pUSpawner;

    public bool CanIncreaseScore
    {
        get { return canIncreaseScore; }
        set { canIncreaseScore = value; }
    }

	void Start () 
    {
        pickUpSpawner = pUSpawner.GetComponent<PickUpSpawner>();
        enemyHealth = enemy.GetComponent<EnemyHealth>();;
        canIncreaseScore = false;
        startingScore = 0;
        currentScore = startingScore;
	}

    private void Update()
    {
        IncreaseScore();
    }

    void IncreaseScore()
    {
        if(canIncreaseScore)
        {
            currentScore += 1; 
            if (currentScore >= scoreToSpawn)
            {
                pickUpSpawner.CanSpawn = true;
            }
            canIncreaseScore = false;
        }
    }
}
