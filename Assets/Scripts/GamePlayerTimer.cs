using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerTimer : MonoBehaviour
{
    #region variables
    // Text assigned variable objects
    public Text timerText;
    public Text gameOverText;
    public Text redWinsText;
    public Text blueWinsText;
    public Text redScoreTimer;
    public Text blueScoreTimer;

    // Important variables
    public float targetTime;
    public Bounds bound;

    // Non text assigned physical objects
    public GameObject gameObject;
    public Image opacity;

    // Extra variables
    private int m_timerBlueScore;
    private int m_timerRedScore;
    private float timeSoFar;
    private bool scoreChecked;

    // IEnumerators
    private IEnumerator coroutine;
    private IEnumerator coroutine2;
    private IEnumerator coroutine3;
    #endregion

    #region setup
    // Set scoreChecked to false
    private void Start()
    {
        scoreChecked = false;
    }
    #endregion

    #region timer
    void Update()
    {
        // Timer setup
        targetTime -= Time.deltaTime;
        timerText.text = ((int)targetTime).ToString();

        // Initial fade
        if(targetTime <= 30 && targetTime >= 25)
        {
            coroutine = disabletimer();
            StartCoroutine(coroutine);
        }
        
        // End of game (timer)
        if (targetTime < 0.0f && scoreChecked == false)
        {
            timerEnded();
            scoreChecked = true;
            coroutine3 = ChangeOpcacity();
            StartCoroutine(coroutine3);
        }

        // Fade in
        if(targetTime <= 5)
        {
            coroutine2 = enabletimer();
            StartCoroutine(coroutine2);
        }
    }
    #endregion

    #region endgame
    // Change text at end of game
    void timerEnded()
    {
        targetTime = 0;
        gameOverText.enabled = true;
        timerText.enabled = false;
        redScoreTimer.enabled = false;
        blueScoreTimer.enabled = false;
        CheckToSeeWhoWon();
    }
    #endregion

    #region finalscore
    void CheckToSeeWhoWon()
    {
        // Fetching scores
        m_timerBlueScore = gameObject.GetComponent<ScoreBoard>().m_blueScore;
        m_timerRedScore = gameObject.GetComponent<ScoreBoard>().m_redScore;

        // Setting scores to compare
        int m_BlueScoreEndedOn = m_timerBlueScore;
        int m_RedScoreEndedOn = m_timerRedScore;

        // Compare scores
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
    #endregion

    #region timeopacity+
    private IEnumerator disabletimer()
    {
        timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, 1);
         while(timerText.color.a > 0.5f)
        {
            timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, timerText.color.a - (Time.deltaTime / 5));
            yield return null;
        }
    }
    #endregion

    #region timeopacity-
    private IEnumerator enabletimer()
    {
        timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, ((float)0.5));
        while (timerText.color.a < 1f)
        {
            timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, timerText.color.a + (Time.deltaTime / 5));
            yield return null;
        }
    }
    #endregion

    #region screenopacity
    private IEnumerator ChangeOpcacity()
    {
        opacity.color = new Color(opacity.color.r, opacity.color.g, opacity.color.b, 0f);
        while (opacity.color.a < 0.84)
        {
            opacity.color = new Color(opacity.color.r, opacity.color.g, opacity.color.b, opacity.color.a + (Time.deltaTime / 3));
            yield return null;
        }
    }
    #endregion
}
