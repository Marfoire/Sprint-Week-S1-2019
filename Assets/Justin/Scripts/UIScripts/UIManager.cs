using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("EndUI")]
    public Text playerScoreText;
    public Text enemyScoreText;
    public GameObject EndUiStatic;
    public GameObject EndUI;

    [Header("SendMessage to chosen object")]
    public GameObject recipient;
    public string message;

    private CenterLine cl;
    private bool waitReset = false;

    private void Awake()
    {
        uiManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartGame");
    }

    public void Update()
    {
        scoreText.text = cl.playerScore + "";

        if (waitReset)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void RegisterCenterLine(CenterLine newCl)
    {
        cl = newCl;
    }
    
    public void EndUi()
    {
        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame()
    {
        EndUI.SetActive(true);
        EndUiStatic.SetActive(true);
        
        int maxScore;
        int tempPlayerScore = 0, tempEnemyScore = 0;

        if (cl.playerScore > cl.enemyScore) maxScore = cl.playerScore;
        else maxScore = cl.enemyScore;

        for(int i = 0; i < maxScore; i++)
        {
            if (cl.enemyScore > i) tempEnemyScore = i+1;
            if (cl.playerScore > i) tempPlayerScore = i+1;

            enemyScoreText.text = tempEnemyScore + "";
            playerScoreText.text = tempPlayerScore + "";
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1);
        waitReset = true;


    }

    public IEnumerator StartGame()
    {
        EndUI.SetActive(false);
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
        GetComponent<GameTimer>().StartTimer();

        yield return new WaitForSeconds(1);
        readyUI.SetActive(false);
        
        yield return null;
    }
}
