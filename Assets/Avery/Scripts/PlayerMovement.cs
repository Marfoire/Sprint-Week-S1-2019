using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    public float walkSpeed;
    public float grappleSpeed;
    public Vector3 movementDirection;
    public GameObject hookshotObject;
    private HookshotBehaviour hookshotScript;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hookshotScript = hookshotObject.GetComponent<HookshotBehaviour>();
    }

    void MovePlayer()
    {
        if (hookshotScript.grappling != true)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalInput = Input.GetAxisRaw("Vertical");

                movementDirection = (horizontalInput * Camera.main.transform.right + verticalInput * Camera.main.transform.forward).normalized;

                Vector3 storedVelocity = rb.velocity;

                rb.velocity = movementDirection * walkSpeed * Time.fixedDeltaTime;

                rb.velocity = new Vector3(rb.velocity.x, storedVelocity.y, rb.velocity.z);
            }
            else
            {
                movementDirection = Vector3.zero;
            }
        }
        else
        {
            movementDirection = (hookshotObject.transform.position - rb.position).normalized;
            rb.velocity = movementDirection * grappleSpeed * Time.fixedDeltaTime;
        }
    }


    void FixedUpdate()
    {
        MovePlayer();
        //for player visuals later transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
