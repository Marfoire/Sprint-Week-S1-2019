using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GamePlayerTimer : MonoBehaviour
{
    public Text timerText;
    public Text gameOverText;

    public Text redWinsText;
    public Text blueWinsText;

    public Text redScoreTimer;
    public Text blueScoreTimer;

    public float targetTime;
    public TextMesh targetTimeMesh;
    public Bounds bound;

    public GameObject gameObject;

    private int m_timerBlueScore;
    private int m_timerRedScore;

    private float timeSoFar;

    private IEnumerator coroutine;
    private IEnumerator coroutine2;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        targetTime -= Time.deltaTime;
        timerText.text = ((int)targetTime).ToString();


        if(targetTime <= 30 && targetTime >= 25)
        {
            coroutine = disabletimer();
            StartCoroutine(coroutine);

        }
        
        if (targetTime <= 0.0f)
        {

            timerEnded();
        }

        if(targetTime <= 10)
        {

            coroutine2 = enabletimer();
            StartCoroutine(coroutine2);


        }

    }

    void timerEnded()
    {
        targetTime = 0;
        gameOverText.enabled = true;

        redScoreTimer.enabled = false;
        blueScoreTimer.enabled = false;


        CheckToSeeWhoWon();
    }


    void CheckToSeeWhoWon()
    {
        m_timerBlueScore = gameObject.GetComponent<ScoreBoard>().m_blueScore;
        m_timerRedScore = gameObject.GetComponent<ScoreBoard>().m_redScore;

        int m_BlueScoreEndedOn = m_timerBlueScore;
        int m_RedScoreEndedOn = m_timerRedScore;

        if(m_BlueScoreEndedOn > m_RedScoreEndedOn)
        {
            // BLUE WINSS
            blueWinsText.enabled = true;

        }

        if (m_RedScoreEndedOn > m_BlueScoreEndedOn)
        {

            // RED WINS
            redWinsText.enabled = true;

        }
    }
    private IEnumerator disabletimer()
    {
        timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, 1);
         while(timerText.color.a > 0.5f)
        {
            timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, timerText.color.a - (Time.deltaTime / 5));
            yield return null;
        }
        
    }


    private IEnumerator enabletimer()
    {
        timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, ((float)0.5));
        while (timerText.color.a < 1f)
        {
            timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, timerText.color.a + (Time.deltaTime / 5));
            yield return null;
        }


    }

}
