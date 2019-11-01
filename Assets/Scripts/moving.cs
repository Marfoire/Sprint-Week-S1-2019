using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    #region variables
    public float pathDistance = 3;
    public float moveSpeed = 2;
    Rigidbody2D Rb2D;
    #endregion

    #region moveplatform
    private void FixedUpdate()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        float newLocation = Mathf.Sin(Time.time * moveSpeed);
        Rb2D.position = new Vector3(newLocation * pathDistance, Rb2D.position.y);
    }
    #endregion
}
