using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookshotInput : MonoBehaviour
{
    [SerializeField]
    private string fireButton;

    private bool shootHookshot;

    public GameObject hookshotObject;

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
           if(hookshotObject.GetComponent<HookshotBehaviour>().isReady == true)
            {
                hookshotObject.GetComponent<HookshotBehaviour>().sender = gameObject;
                hookshotObject.GetComponent<HookshotBehaviour>().FireHookshot();
            }
        }
    }

    void Update()
    {
        TryToFireHookshot();
    }
}
