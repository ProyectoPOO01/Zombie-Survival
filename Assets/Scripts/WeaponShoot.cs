using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;

    public float gravity;
    public float shootDelay;
    public float shootForce;

    bool canShoot = true;

    AudioSource shootAudio;
    Jugador jugador;
    Rigidbody rb;

    void Start ()
    {
        jugador = player.GetComponent<Jugador>();
        rb = bullet.GetComponent<Rigidbody>();
        shootAudio = GetComponent<AudioSource>();
    }
	
	void Update () 
    {
        Disparar();
	}

    void Disparar()
    {
        if (jugador.IsWalking && !jugador.Reloading && jugador.Shooting && canShoot)
        {
            GameObject bullReference = Instantiate(bullet, transform.position, jugador.transform.rotation) as GameObject;
            shootAudio.Play();
            Rigidbody bullRBref = bullReference.GetComponent<Rigidbody>();
            bullRBref.AddForce(-transform.right * shootForce);
            //bullRBref.AddForce(Vector3.down * gravity);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}