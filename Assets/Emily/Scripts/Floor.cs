using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject owner;
    public string Ball;

    //void OnCollisionEnter(Collider other)
    //{
    //    if (other.tag == Ball)
    //    {
    //       // owner.SendMessage("Points", other.gameObject);
    //        //Debug.Log("aaaaaa");
    //        Score.scoreValue += 1; 
    //    }
    //}

    //void OnCollisionExit(Collider other)
    //{
    //    if (other.tag == Ball)
    //    {
    //         owner.SendMessage("Lose", other.gameObject);
    //        //Debug.Log("hewwo");
    //    }
    //}

}
