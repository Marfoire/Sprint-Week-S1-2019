﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed;
    public float jumpForce;

    private float Velocity;
    private float TotalTime;
    private float FinalVelocity;
    private float MagOfSavedVec;
    private Vector3 MySavedVector;

    private Rigidbody2D Rb2D;
    public bool groundCheck;

    void Start()
    {
        AccelerationTime = 0.5f;
        DecelerationTime = 0.5f;
        MaxSpeed = 7;
        jumpForce = 6;

        Rb2D = GetComponent<Rigidbody2D>();
        groundCheck = false;
    }

    void Update()
    {
        Vector2 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveInput != new Vector2(0, 0))
        {
            PlayerMove(moveInput);
        }
    }
    #region playermovement
    void PlayerMove(Vector2 input)
    {
        Vector3 MyVector = new Vector3(input.x, input.y);
        float MagOfVec = MyVector.magnitude;

        if (MagOfVec != 0)
        {
            float Acceleration = MaxSpeed / AccelerationTime;
            Velocity = Acceleration * Time.deltaTime;
            FinalVelocity += Velocity;
            MySavedVector = new Vector3(input.x, 0);
        }
        else
        {
            float Deceleration = MaxSpeed / DecelerationTime;
            Velocity = Deceleration * Time.deltaTime;
            FinalVelocity -= Velocity;
        }

        FinalVelocity = Mathf.Clamp(FinalVelocity, 0, MaxSpeed);
        float Distance = FinalVelocity * Time.deltaTime;
        transform.position += (MySavedVector * Distance);

        if (input.y > 0 && groundCheck == true)
        {
            Rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            groundCheck = false;
        }
    }
    #endregion
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("ball"))
        {
            if (gameObject.name == "Player1")
            {
                collision.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (gameObject.name == "Player2")
            {
                collision.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("small platform") || collision.collider.gameObject.layer == LayerMask.NameToLayer("platform"))
        {
            groundCheck = true;
        }
    }
}