using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;      
    public float maxSpeed;
    public float speed;
    public float rotationspeed;
    public float jumpForce;
    private float horizontal;
    private float vertical;
    private float mouseX;
    public int health;
    private float shift;

    public Transform PartyGoer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");

        float rotation = mouseX * rotationspeed;
        transform.Rotate(Vector3.up, rotation * Time.deltaTime);
        
        if (health <= 0){
            print("dead");
        }

        if (Input.GetKeyDown("left shift"))
        {
            maxSpeed += 50;
        }

        if (Input.GetKeyUp("w"))
        {
            maxSpeed = 2.5f;
        }
        
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DmgBox"))
        {
            health -= 10;
        }
        print(health);
          
        


    }


}
