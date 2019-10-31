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

    // Tracking first velocity
    private Vector2 firstVelocity;

    // Tracking positions and directions
    private Vector2 startPosition;
    public Vector2 direction;
    private Vector2 nextDirection;

    // Paint splatter paint prefabs for instantiating
    public GameObject bluePaint;
    public GameObject redPaint;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        
        //Find random starting direction and speed
        randomAngle = Random.Range(1, 360);
        speed = 9;
        angle = randomAngle * Mathf.Deg2Rad;

        //Find the direction using the angle and set the starting velocity
        firstDirection = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        Rb2D.velocity = firstDirection * speed;
        firstVelocity = Rb2D.velocity;
        startPosition = Rb2D.position;
    }

    void Update()
    {
        Vector3 line2Center = new Vector2(0, 0) - Rb2D.position;
        Debug.DrawLine(Rb2D.position, startPosition, Color.red);

        // Store the previous velocity of the ball for use upon impact with object
        previousVector = Rb2D.velocity;

        if (Rb2D.velocity.magnitude != firstVelocity.magnitude)
        {
            Rb2D.velocity = Rb2D.velocity.normalized * firstVelocity.magnitude;
        }

        // Current direction vector
        direction = Rb2D.velocity.normalized;
        Debug.Log(direction);

        // Reset ball if stuck
        if (direction.x == 0 || direction.y == 0)
        {
            Rb2D.position = startPosition;
            randomAngle = Random.Range(1, 360);
            angle = randomAngle * Mathf.Deg2Rad;
            nextDirection = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            Rb2D.velocity = nextDirection * speed;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check layer of object collided with and reverse appropriate part of velocity
        #region wallCollide
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("wall")) {
            Rb2D.velocity = new Vector3(-previousVector.x, previousVector.y, 0);

            if (this.GetComponent<SpriteRenderer>().color == Color.red)
            {
                GameObject redClone = Instantiate(redPaint, new Vector3(collision.collider.gameObject.transform.position.x, Rb2D.position.y), transform.rotation);
                if (redClone.transform.position.x < 0)
                {
                    redClone.transform.Rotate(0, 0, -90);
                }
                else
                {
                    redClone.transform.Rotate(0, 0, 90);
                }
            } else if (this.GetComponent<SpriteRenderer>().color == Color.cyan)
            {
                GameObject blueClone = Instantiate(bluePaint, new Vector3(collision.collider.gameObject.transform.position.x, Rb2D.position.y), transform.rotation);
                if (blueClone.transform.position.x < 0)
                {
                    blueClone.transform.Rotate(0, 0, -90);
                }
                else
                {
                    blueClone.transform.Rotate(0, 0, 90);
                }
            }
        }
        #endregion

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("platform")) {
            Rb2D.velocity = new Vector3(previousVector.x, -previousVector.y, 0);
            if (this.GetComponent<SpriteRenderer>().color == Color.red)
            {
                GameObject redClone = Instantiate(redPaint, new Vector3(Rb2D.position.x, collision.collider.gameObject.transform.position.y), transform.rotation);
            }
            else if (this.GetComponent<SpriteRenderer>().color == Color.cyan)
            {
                GameObject blueClone = Instantiate(bluePaint, new Vector3(Rb2D.position.x, collision.collider.gameObject.transform.position.y), transform.rotation);
            }
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("ceiling"))
        {
            Rb2D.velocity = new Vector3(previousVector.x, -previousVector.y, 0);
            if (this.GetComponent<SpriteRenderer>().color == Color.red)
            {
                GameObject redClone = Instantiate(redPaint, new Vector3(Rb2D.position.x, collision.collider.gameObject.transform.position.y), transform.rotation);
                redClone.GetComponent<SpriteRenderer>().flipY = false;
            }
            else if (this.GetComponent<SpriteRenderer>().color == Color.cyan)
            {
                GameObject blueClone = Instantiate(bluePaint, new Vector3(Rb2D.position.x, collision.collider.gameObject.transform.position.y), transform.rotation);
                blueClone.GetComponent<SpriteRenderer>().flipY = false;
            }
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("player")) {
            Rb2D.velocity = new Vector3(-previousVector.x, -previousVector.y, 0);
        }
    }
}
