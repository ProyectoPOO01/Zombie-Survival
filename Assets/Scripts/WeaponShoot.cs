using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{

    public GameObject playerGO;
    public GameObject bullet;

    public float timeToDestroy;
    public float shootDelay;
    public float shootForce;

    bool canShoot;

    AudioSource shootAudio;
    PlayerMovement playMov;
    Player player;
    Rigidbody rb;

    void Start ()
    {
        canShoot = true;
        
        playMov = playerGO.GetComponent<PlayerMovement>();
        shootAudio = GetComponent<AudioSource>();
        player = playerGO.GetComponent<Player>();
        rb = bullet.GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        Shoot();
	}
    void Shoot()
    {
        if (playMov.IsWalking && !player.Reloading && player.Shooting && canShoot)
        {
            GameObject bullReference = Instantiate(bullet, transform.position, player.transform.rotation) as GameObject;
            shootAudio.Play();

            Rigidbody bullRBref = bullReference.GetComponent<Rigidbody>();
            bullRBref.AddForce(-transform.right * shootForce);

            Destroy(bullReference, timeToDestroy);

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