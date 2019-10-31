using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject owner;
    public string Ball;
    //depending which collider the ball hits, add +1 score prob debug cause idk ui lol

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Ball)
        {
            // owner.SendMessage("Points", other.gameObject);
            Debug.Log("aaaaaa");
            Score.scoreValue += 1;
        }
    }

    void OnCollisionExit(Collision other)
    {

        Debug.Log("owo");
    }
}
