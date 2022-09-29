using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float life = 3;
    public ParticleSystem dSmoke;
    public AudioSource explosionSound;
    private MeshRenderer meshRenderer;
    private Rigidbody myRb;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        myRb = GetComponent<Rigidbody>();
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyable"))
        {
            Destroy(other.gameObject);

            explosionSound.Play();
            dSmoke.Play();
            dSmoke.transform.SetParent(null);
            explosionSound.transform.SetParent(null);
            meshRenderer.enabled = false;
            myRb.velocity = Vector3.zero;
            myRb.isKinematic = true;

            Destroy(explosionSound.gameObject, 2);
            Destroy(dSmoke.gameObject, 2);
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 2.2f);

        }

        if( other.gameObject.CompareTag("Panel"))
            Destroy(gameObject);
    }
}
  
    
       
    

