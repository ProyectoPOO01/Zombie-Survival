using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionController : MonoBehaviour
{
    PlayerHealth playerHealth;
    GameObject player;

    public GameObject count;
    Text countText;

    private bool isInside;

    private float timer;

	void Start ()
    {
        countText = count.GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        timer = 0;
        isInside = true;
	}
	
	void Update ()
    {
        countText.text = (10 -(int)timer).ToString();

        if (isInside)
        {
            timer = 0;
            count.SetActive(false);
            return;
        }
        else
        {
            count.SetActive(true);
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
