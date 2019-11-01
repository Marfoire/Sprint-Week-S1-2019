using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject owner;
    public string Ball;
    //when the floor detects the tag Ball, it'll sned a msg to the UI canvas and update score

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Ball)
        {
            
            Debug.Log("aaaaaa");
            Score.scoreValue += 1;
        }
    }

    void OnCollisionExit(Collision other)
    {

        Debug.Log("owo");
    }
}
