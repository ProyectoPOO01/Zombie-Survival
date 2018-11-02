using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour 
{
    int startingScore;
    int currentScore;

    public int scoreToSpawn;

    public Text scoreText;

    bool canIncreaseScore;

    EnemyHealth enemyHealth;
    public GameObject enemy;

    PickUpSpawner pickUpSpawner;

    public int CurrentScore
    {
        get { return currentScore; }
    }
    public bool CanIncreaseScore
    {
        get { return canIncreaseScore; }
        set { canIncreaseScore = value; }
    }

	void Start () 
    {
        pickUpSpawner = GetComponent<PickUpSpawner>();
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        canIncreaseScore = false;
        startingScore = 0;
        currentScore = startingScore;
	}

    private void Update()
    {
        scoreText.text = currentScore.ToString();
        IncreaseScore();
    }

    private void IncreaseScore()
    {
        if(canIncreaseScore)
        {
            currentScore += 1; 
            if (currentScore >= scoreToSpawn)
            {
                pickUpSpawner.CanSpawn = true;
                currentScore -= (scoreToSpawn - 1);
            }
            canIncreaseScore = false;
        }
    }
}
