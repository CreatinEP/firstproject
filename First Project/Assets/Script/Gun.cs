using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 50;
    public Collider playerCollider;

    private void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {

    if (Input.GetKeyDown(KeyCode.Mouse0))
     { 
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Physics.IgnoreCollision(playerCollider, bullet.GetComponent<Collider>());
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
     }
    }
}
