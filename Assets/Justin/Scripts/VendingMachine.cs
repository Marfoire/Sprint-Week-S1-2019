using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public float velocityToDispense = 5f;
    public float dispenceForce = 2;
    public string[] tagsToDispense;

    public GameObject kolaCanPrefab;

    private Transform dispenceLocation;

    void Awake()
    {
        dispenceLocation = transform.GetChild(0).transform;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude >= velocityToDispense)
        {
            bool found = false;
            foreach (string i in tagsToDispense)
            {
                if (i.Equals(other.gameObject.tag))
                {
                    found = true;
                }
            }

            if (found)
            {
                Instantiate(kolaCanPrefab, dispenceLocation.position, Quaternion.Euler(0, 0, 90));
            }
        }
    }
}
