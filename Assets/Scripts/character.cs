using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed = 5;

    private float Velocity;
    private float TotalTime;
    private float FinalVelocity;
    private float MagOfSavedVec;
    private Vector3 MySavedVector;

    // Colour change
    public Color player1col;
    public Color player2col;

    void Start()
    {
        AccelerationTime = 0.5f;
        DecelerationTime = 0.5f;
        MaxSpeed = 7;

        player1col = Color.red;
        player1col = Color.blue;
    }

    void Update()
    {
        Vector2 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveInput != new Vector2(0, 0))
        {
            PlayerMove(moveInput);
        }
    }

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
    }
}
