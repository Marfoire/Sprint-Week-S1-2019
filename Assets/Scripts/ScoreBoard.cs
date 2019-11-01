using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreBoard : MonoBehaviour
{
    #region variables
    // Score text
    public Text m_blueTeamScoreText;
    public Text m_redTeamScoreText;
    public int m_blueScore;
    public int m_redScore;

    // Ball array to access later
    public GameObject[] balls;
    #endregion

    #region setvariables
    private void Start()
    {
        m_blueTeamScoreText.text = m_blueScore.ToString();
        m_redTeamScoreText.text = m_redScore.ToString();
    }
    #endregion

    #region paintballsquish
    // Add bonus points for squishing the paintballs
    void FixedUpdate()
    {
        foreach (GameObject ball in balls)
        {
            if (ball.GetComponent<spee>().direction.x == 0 || ball.GetComponent<spee>().direction.y == 0)
            {
                if (ball.GetComponent<SpriteRenderer>().color == Color.red)
                {
                    // Increase red's score
                    IncreaseRedTeamScore50();
                }

                if (ball.GetComponent<SpriteRenderer>().color == Color.blue)
                {
                    // Increase blue's score
                    IncreaseBlueTeamScore50();
                }
            }
        }
    }
    #endregion

    #region bluescore
    public void IncreaseBlueTeamScore()
    {
        m_blueScore++;
        m_blueTeamScoreText.text = m_blueScore.ToString();
    }

    public void IncreaseBlueTeamScore50()
    {
        m_blueScore += 50;
        m_blueTeamScoreText.text = m_blueScore.ToString();
    }
    #endregion

    #region redscore
    public void IncreaseRedTeamScore()
    {
        m_redScore++;
        m_redTeamScoreText.text = m_redScore.ToString();
    }

    public void IncreaseRedTeamScore50()
    {
        m_redScore += 50;
        m_redTeamScoreText.text = m_redScore.ToString();
    }
    #endregion

    #region increasescore
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("ball"))
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                // Increase red's score
                IncreaseRedTeamScore();
            }

            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.blue)
            {
                // Increase blue's score
                IncreaseBlueTeamScore();
            }
        }
    }
    #endregion
}
