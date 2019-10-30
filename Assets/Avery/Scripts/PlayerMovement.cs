using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    public float walkSpeed;
    public Vector3 movementDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void MovePlayer()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            movementDirection = (horizontalInput * Camera.main.transform.right + verticalInput * Camera.main.transform.forward).normalized;

            float storedYVelocity = rb.velocity.y;

            rb.velocity = movementDirection * walkSpeed * Time.fixedDeltaTime;

            rb.velocity = new Vector3(rb.velocity.x, storedYVelocity, rb.velocity.z);
        }
        else
        {
            movementDirection = Vector3.zero;

        }
    }


    void FixedUpdate()
    {
        MovePlayer();
        //for player visuals later transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
