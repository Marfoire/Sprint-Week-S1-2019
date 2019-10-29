using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject owner;
    public string Floor;
    //depending which collider the ball hits, add +1 score prob debug cause idk ui lol

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Floor)
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
