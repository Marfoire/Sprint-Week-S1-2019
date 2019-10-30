using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public KeyCode throwButton = KeyCode.Mouse0;

    public float ballDistanceOffset = 1;

    public float launchForce = 3;

    public float grabRange = 3;
    public LayerMask ballLayer;

    private GameObject heldBall;

    // Update is called once per frame
    void Update()
    {
        if(heldBall) heldBall.transform.position = transform.position + transform.forward;

        Transform cameraTransform = Camera.main.transform;
        if (Input.GetKeyDown(throwButton))
        {

            if (heldBall)
            {
                Vector3 launchVector = cameraTransform.forward * launchForce;

                Debug.Log(launchVector);

                heldBall.GetComponent<Rigidbody>().AddForce(launchVector, ForceMode.Impulse);
                heldBall.transform.parent = null;
                heldBall = null;
            } else
            {
                Collider[] balls = Physics.OverlapSphere(transform.position, grabRange, ballLayer);
                

                if (balls.Length > 0)
                {
                    heldBall = balls[0].gameObject;
                    balls[0].transform.parent = transform;
                    
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
