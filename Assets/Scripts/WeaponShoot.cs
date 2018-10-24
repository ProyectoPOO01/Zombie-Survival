using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{

    public GameObject playerGO;
    public GameObject bullet;

    public float timeDestroy;

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
    GameObject bullReference;
    public GameObject BullReference
    {
        get { return bullReference; }
        set { bullReference = value; }
    }
    void Shoot()
    {
        float timer = 0;
        if (playMov.IsWalking && !player.Reloading && player.Shooting && canShoot)
        {
            bullReference = Instantiate(bullet, transform.position, player.transform.rotation) as GameObject;
            shootAudio.Play();

            Rigidbody bullRBref = bullReference.GetComponent<Rigidbody>();
            bullRBref.AddForce(-transform.right * shootForce);

            canShoot = false;

            timer = 0;
            timer += Time.deltaTime;
            if (timer >= timeDestroy)
            {
                Destroy(bullReference);
            }
            StartCoroutine(ShootDelay());
        }

        Debug.Log(timer);
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}