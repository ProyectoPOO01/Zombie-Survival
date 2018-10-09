using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour 
{
    NavMeshAgent agent;
    Transform target;
    Jugador jugador;
    Animator anim;

    public NavMeshAgent Agent
    {
        get { return agent; }
    }
    public Transform Target
    {
        get { return target; }
    }
    public Jugador Jugad
    {
        get { return jugador; }
    }
    public Animator Anim
    {
        get { return anim; }
    }

    public GameObject player;
    bool playerInRange;

	void Start ()
    {
        anim = GetComponent<Animator>();
        target = player.transform;
        jugador = player.GetComponent<Jugador>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Perseguir();
	}

    void Perseguir()
    {
        if(jugador.CurrentHealth > 0 && !playerInRange)
        {
            anim.SetBool("PlayerAlive", true);
            anim.SetBool("Walk", true);
            anim.SetBool("PlayerInRange", false);
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
        if(jugador.CurrentHealth > 0 && playerInRange)
        {
            anim.SetBool("PlayerAlive", true);
            anim.SetBool("PlayerInRange", true);
            anim.SetBool("Walk", false);
            agent.isStopped = true;
        }
        if(jugador.CurrentHealth == 0)
        {
            anim.SetBool("PlayerAlive", false);
            anim.SetBool("Walk", false);
            anim.SetBool("PlayerInRange", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
