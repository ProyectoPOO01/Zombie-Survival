using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShoot : MonoBehaviour
{
    [Header("Gameobjects")]
    [Space(10)]
    public GameObject playerGO;
    public GameObject bullet;

    [Header("Bullet Properties")]
    [Space(10)]
    public float timeToDestroy;
    public float shootDelay;
    public float shootForce;

    [Header("Canvas")]
    [Space(10)]
    public Text ammoText;
    public Text cartridgeText;

    [Header("Audio")]
    [Space(10)]
    public AudioClip shootAudio;
    public AudioClip noAmmo;

    private bool canShoot;

    private int ammo;
    private int maxAmmo;
    private int ammoCartridge;
    private int maxAmmoCartridge;

    AudioSource audio01;
    PlayerMovement playMov;
    Player player;
    Rigidbody rb;

    public int Ammo
    {
        get { return ammo; }
        set { ammo = value; }
    }
    public int MaxAmmo
    {
        get { return maxAmmo; }
    }
    public int AmmoCartridge
    {
        get { return ammoCartridge; }
        set { ammoCartridge = value; }
    }
    public int MaxAmmoCartridge
    {
        get { return maxAmmoCartridge; }
    }

    void Start ()
    {
        maxAmmoCartridge = 3;
        ammoCartridge = 4;
        maxAmmo = 31;
        ammo = maxAmmo;
        canShoot = true;
        
        playMov = playerGO.GetComponent<PlayerMovement>();
        audio01 = GetComponent<AudioSource>();
        player = playerGO.GetComponent<Player>();
        rb = bullet.GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        ammoText.text = ammo.ToString();
        cartridgeText.text = ammoCartridge.ToString();
        Shoot();
	}
    void Shoot()
    {
        if (playMov.IsWalking && !player.Reloading && player.Shooting && canShoot && ValidateAmmo(ammo))
        {
            GameObject bullReference = Instantiate(bullet, transform.position, player.transform.rotation) as GameObject;
            audio01.PlayOneShot(shootAudio);

            Rigidbody bullRBref = bullReference.GetComponent<Rigidbody>();
            bullRBref.AddForce(-transform.right * shootForce);

            Destroy(bullReference, timeToDestroy);

            canShoot = false;

            StartCoroutine(ShootDelay());

            ammo -= 1;
        }

        if(playMov.IsWalking && !player.Reloading && Input.GetKeyDown(KeyCode.Mouse0) && canShoot && !ValidateAmmo(ammo))
        {
            audio01.PlayOneShot(noAmmo);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    private bool ValidateAmmo(int currentAmmo)
    {
        if(currentAmmo > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ValidateAmmoCartridge(int currentAmmoCartridge)
    {
        if (currentAmmoCartridge > 0)
        {
            Debug.Log(currentAmmoCartridge);
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}