using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingFlash : MonoBehaviour
{
    public GameObject readyUI;
    public Text counter;
    public GameObject ready;
    public GameObject go;

    [Header("SendMessage to chosen object")]
    public GameObject recipient;
    public string message;

    public IEnumerator StartGame()
    {
        readyUI.SetActive(true);
        go.SetActive(false);
        ready.SetActive(true);

        counter.text = "3";

        yield return new WaitForSeconds(1);

        counter.text = "2";

        yield return new WaitForSeconds(1);
        counter.text = "1";

        yield return new WaitForSeconds(1);
        go.SetActive(true);
        ready.SetActive(false);
        counter.text = "";

        if (recipient)
        {
            recipient.SendMessage(message);
        }
    }
}
