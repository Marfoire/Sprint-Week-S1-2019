﻿using System.Collections;
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
        ToggleSenderCollision(true);
    }

    public void ResetHookshot()
    {
        isReady = true;
        rb.velocity = Vector3.zero;
        transform.localPosition = startPos;
    }

    public void FireHookshot()
    {
        if (isReady)
        {
            ToggleSenderCollision(true);
            GetComponent<Collider>().isTrigger = false;
            transform.parent = null;
            travelDirection = Camera.main.transform.forward;
            rb.rotation = Quaternion.LookRotation(travelDirection);
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
        if (travelStartTime + travelTime < Time.fixedTime && isReady == false && grappling == false)
        {
            returning = true;
        }
    }

    public void ReturnHookshot()
    {
        if (returning)
        {
            GetComponent<Collider>().isTrigger = true;
            ToggleSenderCollision(false);
            travelDirection = (Camera.main.transform.position - rb.position).normalized;
            rb.rotation = Quaternion.LookRotation(travelDirection);
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
        if (other.gameObject == sender && grappling)
        {
            grappling = false;
            transform.parent = Camera.main.transform;
            ResetHookshot();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {     
        if (collision.gameObject.tag == "Environment" && isReady == false && returning == false)
        {
            rb.velocity = Vector3.zero;
            grappling = true;
            GetComponent<Collider>().isTrigger = true;
            ToggleSenderCollision(false);
        }
        else if(collision.gameObject.tag == "Ball" && isReady == false && returning == false)
        {
            GetComponent<Collider>().isTrigger = true;
            ToggleSenderCollision(false);
        }
    }

    public void ToggleSenderCollision(bool shouldIgnore)
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), sender.GetComponent<Collider>(), shouldIgnore);
    }

    void FixedUpdate()
    {
        if (isReady == false)
        {
            FireHookshot();
        }
        ShouldHookshotReturn();
        ReturnHookshot();
    }

    private void Update()
    {
        if (isReady == true)
        {
            ResetHookshot();
        }
    }

}