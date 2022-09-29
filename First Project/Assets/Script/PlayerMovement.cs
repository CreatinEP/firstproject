using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 10;
    [SerializeField]
    private MeshRenderer meshRenderer;
    [SerializeField]
    public Rigidbody rb;
    public LayerMask groundLayers;
    public float jumpForce = 10;
    public SphereCollider col;

    public Gun myGun;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        col = GetComponent<SphereCollider>();
        jumpForce = 10;


    }

    // Update is called once per frame
    void Update()
    {

        //
        Vector3 position = this.transform.position;
        position.z += 0.04f;
        this.transform.position = position;
        //

        //float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, verticalInput) * moveSpeed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), transform.position.y, transform.position.z);


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         
        }


    }
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 1f, groundLayers);
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Panel"))
        {
            Color panelColor = other.GetComponent<MeshRenderer>().material.color;
            Material mat2 = meshRenderer.material;
            Material mat = other.GetComponent<MeshRenderer>().material;
            mat2.color = mat.color;
            meshRenderer.material = mat2;
            myGun.GetComponent<MeshRenderer>().material = mat2;

            Destroy(other.gameObject);

        }

         
    }

}
