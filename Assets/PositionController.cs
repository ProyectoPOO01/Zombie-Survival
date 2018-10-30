using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{

    PlayerHealth playerHealth;
    GameObject player;

    public float decreaseValue;
    public float decreaseTime;

    private bool isInside;

    private float timer;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        timer = 0;
        isInside = true;
	}
	
	void Update ()
    {
        if (isInside)
        {
            timer = 0;
            return;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (timer >= 10)
        {
            playerHealth.CurrentHealth = 0;
        }
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInside = false;
        }
    }
}
