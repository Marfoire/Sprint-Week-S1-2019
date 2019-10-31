using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookshotBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    public bool isReady;
    public bool returning;
    public bool grappling;
    public bool cancelledShot;
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
        if (transform.childCount != 0)
        {
            Physics.IgnoreCollision(transform.GetChild(0).GetComponent<Collider>(), sender.GetComponent<Collider>(), false);
            if (!sender.GetComponent<ThrowBall>().GetHeldBall())
            {
                transform.GetChild(0).GetComponent<Rigidbody>();
                sender.GetComponent<ThrowBall>().GrabBall(transform.GetChild(0).gameObject);
            }
            else
            {               
                transform.GetChild(0).parent = null;
            }
        }
       /* if (sender.GetComponent<ThrowBall>().GetHeldBall()) //hookshot probably isn't the place to do this
        {
            sender.GetComponent<ThrowBall>().GetHeldBall().GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }*/

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

            if (transform.childCount != 0)
            {
                if (!cancelledShot)
                {
                    Physics.IgnoreCollision(transform.GetChild(0).GetComponent<Collider>(), sender.GetComponent<Collider>(), true);
                    transform.GetChild(0).GetComponent<Rigidbody>().velocity = rb.velocity;
                    transform.GetChild(0).GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
                else
                {
                    Physics.IgnoreCollision(transform.GetChild(0).GetComponent<Collider>(), sender.GetComponent<Collider>(),false);
                    transform.GetChild(0).parent = null;
                }
            }
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
        if (collision.gameObject.tag == "Ball" && isReady == false && returning == false)
        {
            collision.transform.parent = transform;
            GetComponent<Collider>().isTrigger = true;
            ToggleSenderCollision(false);
            returning = true;
        }
        else if (collision.gameObject.tag == "Environment" && isReady == false && returning == false)
        {
            rb.velocity = Vector3.zero;
            grappling = true;
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
