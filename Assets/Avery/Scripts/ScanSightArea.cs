using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanSightArea : MonoBehaviour
{

    /// <summary>
    /// String that represents the tag that I'll filter for when scanning for targets
    /// </summary>
    public string tagToScanFor;

    /// <summary>
    /// List of gameObjects that fulfill my targetting criteria
    /// </summary>
    public List<GameObject> targetsInRange = new List<GameObject>();


    //add targets that are now in range
    private void OnTriggerEnter(Collider other)

    {
        //if the collider has the tag we're scanning for and that object isn't in the list already for whatever reason
        if (other.tag == tagToScanFor && !targetsInRange.Contains(other.gameObject))

        {

            //add to the list
            targetsInRange.Add(other.gameObject);

        }

    }

    //remove targets that are no longer in range
    private void OnTriggerExit(Collider other)

    {

        //if the list has the departing collider object

        if (targetsInRange.Contains(other.gameObject))

        {

            //remove it from the list

            targetsInRange.Remove(other.gameObject);

        }

    }

    private void FixedUpdate()
    {
        for (int i = targetsInRange.Count - 1; i >= 0; i--)
        {
            if (!targetsInRange[i])
            {
                targetsInRange.RemoveAt(i);
            }
        }
    }

}