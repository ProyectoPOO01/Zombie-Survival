using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    public float sceneDelay;

    GameObject player;
    PlayerHealth playerHealth;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        ChangeScene();
    }
    void ChangeScene()
    {
        if (playerHealth.PlayerDead)
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
