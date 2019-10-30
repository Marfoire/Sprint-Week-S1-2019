using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookshotInput : MonoBehaviour
{
    [SerializeField]
    private string fireButton;

    private bool shootHookshot;

    public GameObject hookshotObject;
    private HookshotBehaviour hookshotScript;

    private void Awake()
    {
        hookshotScript = hookshotObject.GetComponent<HookshotBehaviour>();
    }


    private void OnGUI()
    {
        if (Input.GetButtonDown(fireButton))
        {
            shootHookshot = true;
        }
        else
        {
            shootHookshot = false;
        }
    }

    public void TryToFireHookshot()
    {
        if (hookshotObject && shootHookshot == true)
        {
           if(hookshotScript.isReady == true)
            {
                hookshotScript.sender = gameObject;
                hookshotScript.FireHookshot();
            }
            else
            {
                hookshotScript.returning = true;
                hookshotScript.grappling = false;
            }
        }
    }

    void Update()
    {
        TryToFireHookshot();
    }
}
