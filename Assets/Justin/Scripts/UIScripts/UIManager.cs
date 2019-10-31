using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;

    public GameObject readyUI;
    public Text counter;
    public Text scoreText;
    public GameObject ready;
    public GameObject go;
    public GameObject timeLimit;
    public Color color1;
    public Color color2 = new Color(140, 140, 0);
    public Color color3 = new Color(255, 255, 0);

    [Header("SendMessage to chosen object")]
    public GameObject recipient;
    public string message;

    private void Awake()
    {
        uiManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartGame");
    }

    public void setScore(float score)
    {
        scoreText.text = score + "";
    }
    

    public IEnumerator StartGame()
    {
        scoreText.gameObject.SetActive(false);
        readyUI.SetActive(true);
        timeLimit.SetActive(true);

        yield return new WaitForSeconds(2);

        timeLimit.SetActive(false);
        
        counter.gameObject.SetActive(true);
        go.SetActive(false);
        ready.SetActive(true);

        counter.color = color1;
        counter.text = "3";        

        yield return new WaitForSeconds(1);

        counter.color = color2;
        counter.text = "2";        

        yield return new WaitForSeconds(1);

        counter.color = color3;
        counter.text = "1";        

        yield return new WaitForSeconds(1);

        go.SetActive(true);
        ready.SetActive(false);
        scoreText.gameObject.SetActive(true);
        counter.text = "";
        if (recipient)
        {
            recipient.SendMessage(message);
        }

        yield return new WaitForSeconds(1);
        readyUI.SetActive(false);
        
        yield return null;
    }
}
