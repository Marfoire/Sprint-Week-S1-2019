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

    public GameObject coll;

    private int m_timerBlueScore;
    private int m_timerRedScore;

    private IEnumerator coroutine;
    
    // Update is called once per frame
    void Update()
    {

        targetTime -= Time.deltaTime;
        timerText.text = ((int)targetTime).ToString();

        coroutine = disabletimer(5);
        StartCoroutine(coroutine);
        if (targetTime <= 0.0f)
        {

            timerEnded();
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

        if( m_timerBlueScore > m_timerRedScore)
        {
            // BLUE WINSS
            blueWinsText.enabled = true;

        }

        if (m_timerRedScore > m_timerBlueScore)
        {

            // RED WINS
            redWinsText.enabled = true;

        }
    }
    private IEnumerator disabletimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        timerText.enabled = false;

    }

}
