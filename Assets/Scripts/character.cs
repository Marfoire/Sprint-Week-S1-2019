using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    #region variables
    // Movement speeds
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed;
    public float jumpForce;

    // Stored velocity variables
    private float Velocity;
    private float TotalTime;
    private float FinalVelocity;
    private float MagOfSavedVec;
    private Vector3 MySavedVector;

    // Setting up the player character
    private Rigidbody2D Rb2D;
    private Vector2 start;

    // Ground and air check
    public bool groundCheck;
    public bool airCheck;

    // Move input
    public Vector2 moveInput;

    SpriteRenderer playerSprite;
    #endregion

    #region setup
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        start = Rb2D.position;

        playerSprite = GetComponent<SpriteRenderer>();
        AccelerationTime = 0.5f;
        DecelerationTime = 0.5f;
        MaxSpeed = 7;
        jumpForce = 4;

        groundCheck = false;

        // Start player in right direction
        if (gameObject.name == "Player1")
        {
            playerSprite.flipX = true;
        }
    }
    #endregion

    #region getInput
    // Getting player input and player reset function
    void Update()
    {
        // Reset player 1
        if (gameObject.name == "Player1")
        {
            if (Input.GetKeyDown("left shift"))
            {
                Rb2D.velocity = Vector2.zero;
                Rb2D.position = start;
            }
        }

        // Reset player 2
        if (gameObject.name == "Player2")
        {
            if (Input.GetKeyDown("right shift"))
            {
                Rb2D.velocity = Vector2.zero;
                Rb2D.position = start;
            }
        }

        if (gameObject.name == "Player1")
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));
        }

        if (gameObject.name == "Player2")
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        }

        if (moveInput != new Vector2(0, 0))
        {
            PlayerMove(moveInput);
        }
    }
    #endregion

    #region playermovement
    // Moving the player
    void PlayerMove(Vector2 input)
    {
        Vector3 MyVector = new Vector3(input.x, input.y);
        float MagOfVec = MyVector.magnitude;

        // Flip sprite correct way
        if (input.x < 0)
        {
            playerSprite.flipX = false;
        }
        
        if (input.x > 0)
        {
            playerSprite.flipX = true;
        }

        // handling acceleration and deceleration
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

        // Adding jump force
        if (input.y > 0 && groundCheck == true)
        {
            Rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            groundCheck = false;
        }

        // Dive/slam implementation
        if (input.y < 0 && groundCheck == false && airCheck == true)
        {
            if (Rb2D.velocity.y < 0)
            {
                Rb2D.velocity = new Vector2(Rb2D.velocity.x, Rb2D.velocity.y * 5);
            }

            if (Rb2D.velocity.y > 0 && Rb2D.velocity.y < 10)
            {
                Rb2D.velocity = new Vector2(Rb2D.velocity.x, -Rb2D.velocity.y * 5);
            }
            airCheck = false;
        }
    }
    #endregion

    #region collisions
    // Color the balls correctly
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
    }

    // Ground check and air check
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("small platform") || collision.collider.gameObject.layer == LayerMask.NameToLayer("platform"))
        {
            groundCheck = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("small platform") || collision.collider.gameObject.layer == LayerMask.NameToLayer("platform"))
        {
            groundCheck = false;
            airCheck = true;
        }
    }
    #endregion
}
