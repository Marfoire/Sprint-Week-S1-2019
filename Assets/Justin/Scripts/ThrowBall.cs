using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public KeyCode throwButton = KeyCode.Mouse0;
    public float launchForce = 3;
    public float grabRange = 3;
    public LayerMask ballLayer;

    private GameObject heldBall;

    // Update is called once per frame
    void Update()
    {
        Transform cameraTransform = Camera.main.transform;

        if (heldBall) heldBall.transform.position = transform.position + cameraTransform.forward;
        
        if (Input.GetKeyDown(throwButton))
        {

            if (heldBall)
            {
                Vector3 launchVector = cameraTransform.forward * launchForce;
                LaunchBall(launchVector);
            }
            else
            {
                Collider[] balls = Physics.OverlapSphere(transform.position, grabRange, ballLayer);

                if (balls.Length > 0)
                {
                    GrabBall(balls[0].gameObject);
                }
            }
        }
    }

    /// <summary>
    /// Simply releases the ball from the player's grasp. Lets it drop
    /// </summary>
    public void ReleaseBall()
    {
        if (heldBall)
        {
            heldBall.transform.parent = null;
            heldBall = null;
        }
    }
    /// <summary>
    /// Launches the ball, and sets the velocity to the passed value
    /// </summary>
    /// <param name="velocity">the velocity to set the ball to</param>
    public void LaunchBall(Vector3 velocity)
    {
        heldBall.transform.parent = null;
        heldBall.GetComponent<Rigidbody>().velocity = velocity;
        heldBall = null;
    }
    /// <summary>
    /// Grabs a passed gameobject. Assumes the passed object is valid to be grabbed.
    /// </summary>
    /// <param name="ball">the gameobjct to grab on to</param>
    public void GrabBall(GameObject ball)
    {
        ReleaseBall();
        heldBall = ball;
        ball.transform.parent = transform;
    }
    public GameObject GetHeldBall()
    {
        return heldBall;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
