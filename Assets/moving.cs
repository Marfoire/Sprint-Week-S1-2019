using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float pathDistance = 3;
    public float moveSpeed = 2;

    private void FixedUpdate()
    {
        Rigidbody2D Rb2D = GetComponent<Rigidbody2D>();
        float newLocation = Mathf.Sin(Time.time * moveSpeed);
        Rb2D.position = new Vector3(newLocation * pathDistance, Rb2D.position.y);
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }*/
}
