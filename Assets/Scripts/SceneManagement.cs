using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    public float sceneDelay;

    GameObject player;
    GameObject Boss;

    EnemySpawn enemySpawn;

    PlayerHealth playerHealth;
    void Start()
    {
        enemySpawn = GetComponent<EnemySpawn>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    bool Set;
    private void Update()
    {
        if (enemySpawn.BossSpawned)
        {
            Boss = GameObject.Find("Boss");
        }
        ChangeScene();
    }
    void ChangeScene()
    {
        if (playerHealth.PlayerDead || Boss.GetComponent<EnemyHealth>().CurrentHealth <= 0)
        {
            StartCoroutine(ChangeSceneDelay());
        }
    } 

    IEnumerator ChangeSceneDelay()
    {
        yield return new WaitForSeconds(sceneDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
