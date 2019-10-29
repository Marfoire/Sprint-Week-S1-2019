using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    public float distance = 2;

    public float height = 1;

    void LateUpdate()
    {
        if (target)
        {
            transform.position = target.transform.position + (distance * -target.transform.forward) + (height * Vector3.up);
           // transform.rotation = target.transform.rotation;
        }
    }
}
