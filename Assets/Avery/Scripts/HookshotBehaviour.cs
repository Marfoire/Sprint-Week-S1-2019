using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookshotBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    public bool isReady;
    public bool returning;
    public bool grappling;
    public float travelTime;
    private float travelStartTime;
    public Vector3 travelDirection;
    public float travelSpeed;

    public GameObject sender;

    private Vector3 startPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.localPosition;       
    }


    public void FireHookshot()
    {
        if (isReady)
        {
            transform.parent = null;
            travelDirection = Camera.main.transform.forward;
            transform.rotation = Quaternion.LookRotation(travelDirection);
            travelStartTime = Time.fixedTime;
            isReady = false;
        }
        if(isReady == false && returning == false && grappling == false)
        {
            rb.velocity = travelSpeed * travelDirection;
        }
    }

    public void ShouldHookshotReturn()
    {
        if (travelStartTime + travelTime < Time.fixedTime && isReady == false)
        {
            returning = true;
        }
    }

    public void ReturnHookshot()
    {
        if (returning)
        {
            travelDirection = (Camera.main.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(travelDirection);
            rb.velocity = travelSpeed * travelDirection;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == sender && returning)
        {
            returning = false;
            transform.parent = Camera.main.transform;
            ResetHookshot();
        }
    }

    public void ResetHookshot()
    {
        isReady = true;
        rb.velocity = Vector3.zero;
        transform.localPosition = startPos;
    }


    void FixedUpdate()
    {
        if (isReady == false)
        {
            FireHookshot();
        }
        else if(returning == false && grappling == false)
        {
            ResetHookshot();
        }
        ShouldHookshotReturn();
        ReturnHookshot();
    }
}
