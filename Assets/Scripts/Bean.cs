using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;    public float maxSpeed;
    public float speed;
    public float rotationspeed;
    public float jumpForce;
    private float horizontal;
    private float vertical;
    private float mouseX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");

        float rotation = mouseX * rotationspeed;
        transform.Rotate(Vector3.up, rotation * Time.deltaTime);

        
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * vertical * speed * Time.deltaTime);
        rb.AddForce(transform.right * horizontal * speed * Time.deltaTime);

       if(rb.velocity.magnitude > maxSpeed)
       {
        rb.velocity = rb.velocity.normalized * maxSpeed;
       } 
    }


}
