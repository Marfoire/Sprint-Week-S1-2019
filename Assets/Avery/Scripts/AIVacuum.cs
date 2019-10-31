using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIVacuum : MonoBehaviour
{
    public GameObject playerObject;
    public float throwForce;
    private ScanSightArea scanner;
    private NavMeshAgent agent;
    private bool invokeScan;
    private GameObject target;

    private void Awake()
    {
        scanner = GetComponentInChildren<ScanSightArea>();
        agent = GetComponent<NavMeshAgent>();
    }

    private bool AreThereBallsInRange()
    {
        if (scanner.targetsInRange.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FindATarget()
    {
        float lowestSqrMagnitude = 10000000;

        invokeScan = false;

        if (AreThereBallsInRange() == true)
        {
            foreach (GameObject potentialTarget in scanner.targetsInRange)
            {
                if (potentialTarget && potentialTarget.GetComponent<BallSide>().side == -1)
                {
                    if (lowestSqrMagnitude > Vector3.SqrMagnitude(transform.position - potentialTarget.GetComponent<Rigidbody>().position))
                    {
                        lowestSqrMagnitude = Vector3.SqrMagnitude(transform.position - potentialTarget.GetComponent<Rigidbody>().position);
                        target = potentialTarget;
                    }
                }
            }
        }
        else
        {
            target = null;
        }
    }


    private void UpdateDestination()
    {
        if (target)
        {
            agent.destination = target.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            if (playerObject)
            {
                other.attachedRigidbody.velocity = throwForce * ((playerObject.GetComponent<Rigidbody>().position + Vector3.up * Random.Range(2,7)) - transform.position).normalized;

                if(other.gameObject == target)
                {
                    Invoke("FindATarget", 0.15f);
                }
            }
        }
    }

    void Update()
    {        
        if (!target && AreThereBallsInRange() == true)
        {
            FindATarget();
        }
        else if (!invokeScan)
        {
            invokeScan = true;
            Invoke("FindATarget", 0.5f);
        }
        UpdateDestination();
    }

}
