using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spee : MonoBehaviour
{
    // Initial velocity
    public Rigidbody2D Rb2D;
    public Vector3 velocity;
    public float speed;
    public float randomAngle;
    public float angle;
    public float startDirection;
    public Vector3 firstDirection;

    // When hiting an object
    public Vector3 newDirection;

    // Start is called before the first frame update
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        //direction is a random angle
        randomAngle = Random.Range(0, 360);
        //find the arc tan of the angle for use later
        startDirection = Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
        //add the arc tan to thestarting angle of 0
        angle = (startDirection + randomAngle) * Mathf.Deg2Rad;
        //finally set the velocity using the direction
        firstDirection = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        speed = 6;
        Rb2D.velocity = firstDirection * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    void OnCollisionEnter2D(Collision collision)
    {
        // 
        //calculate the angle between the balls directional vector and the surface vector
        //flip it to bounce off in opposite direction
    }
}
