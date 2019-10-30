using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    public float moveSpeed = 3;
    public float maxXOffset;

    private Vector3 initialPosition;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveSpeed, 0, 0);

        if(transform.position.x >= initialPosition.x + maxXOffset)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(initialPosition.x + maxXOffset, 0, 0));
        Gizmos.color = Color.white;
    }
}
