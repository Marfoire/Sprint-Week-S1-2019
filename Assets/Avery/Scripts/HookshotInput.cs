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

    public AudioClip hookShotLaunchsound;

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
                hookshotScript.cancelledShot = false;
                hookshotScript.sender = gameObject;
                hookshotScript.FireHookshot();
                AudioManager.instance.PlaySound(gameObject, hookShotLaunchsound);
            }
            else
            {
                hookshotScript.returning = true;
                hookshotScript.cancelledShot = true;
                hookshotScript.grappling = false;
            }
        }
    }

    void Update()
    {
        TryToFireHookshot();
    }
}
