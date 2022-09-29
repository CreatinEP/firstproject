using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public PlayerMovement player;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 50;
    public Collider playerCollider;
    public ParticleSystem fSmoke;
    public AudioSource gunSound;
    public float fireRate;
    float nextFire;


    private void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    if (Input.GetKeyDown(KeyCode.Mouse0))
     {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            bullet.GetComponent<MeshRenderer>().material = player.GetComponent<MeshRenderer>().material;

            Physics.IgnoreCollision(playerCollider, bullet.GetComponent<Collider>());
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;  
            gunSound.Play();
            fSmoke.Play();
        }
   
    }
}
