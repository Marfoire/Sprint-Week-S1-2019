using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spee : MonoBehaviour
{
    // Initial velocity
    private Rigidbody2D Rb2D;
    public float speed;
    private float randomAngle;
    private float angle;
    private Vector2 firstDirection;

    // When hiting an object
    private Vector2 previousVector;
    private float newAngle;
    private Vector2 directionFinal;

    private Vector2 firstVelocity;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        
        //Find random starting direction and speed
        randomAngle = Random.Range(0, 360);
        speed = 9;
        angle = randomAngle * Mathf.Deg2Rad;

        //Find the direction using the angle and set the starting velocity
        firstDirection = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        Rb2D.velocity = firstDirection * speed;
        firstVelocity = Rb2D.velocity;
    }

    void Update()
    {
        Vector3 line2Center = new Vector2(0, 0) - Rb2D.position;
        Debug.DrawLine(Rb2D.position, new Vector2(0, 0), Color.red);

        // Store the previous velocity of the ball for use upon impact with object
        previousVector = Rb2D.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check layer of object collided with and reverse appropriate part of velocity
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("wall")) {
            Rb2D.velocity = new Vector3(-previousVector.x, previousVector.y, 0);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("platform")) {
            Rb2D.velocity = new Vector3(previousVector.x, -previousVector.y, 0);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("player")) {
            Rb2D.velocity = new Vector3(-previousVector.x, -previousVector.y, 0);
        }

        //NOTE: This method won't work for objects that can be hit from more than one side. For the shield and platforms, this method won't work (will need additional if statements).
        // Also, sorry about the name of the script.
    }
}
