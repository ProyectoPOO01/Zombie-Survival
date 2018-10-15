using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour 
{
    public float timeToDestroy;
    float timer;
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        Destruir();
	}

    void Destruir()
    {
        if(timer >= timeToDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
