using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class ScoreBoard : MonoBehaviour
{
    public Text m_blueTeamScoreText;
    public Text m_redTeamScoreText;

    public int m_blueScore;
    public int m_redScore;



    private void Start()
    {
        m_blueTeamScoreText.text = m_blueScore.ToString();
        m_redTeamScoreText.text = m_redScore.ToString();
    }



    private void Update()
    {
        m_blueTeamScoreText.text = m_blueScore.ToString();
        m_redTeamScoreText.text = m_redScore.ToString();
    }
    #region BlueTeamScore
    public void IncreaseBlueTeamScore()
    {
        m_blueScore++;
        m_blueTeamScoreText.text = m_blueScore.ToString();
    }
    #endregion

    #region RedTeamScore
    public void IncreaseRedTeamScore()
    {
        m_redScore++;
        m_redTeamScoreText.text = m_redScore.ToString();

    }
    #endregion



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("ball"))
        {

            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                IncreaseRedTeamScore();
                
                Debug.Log("redteamscore");
            }

            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.blue)
            {
                IncreaseBlueTeamScore();
                Debug.Log("blueteamscored");

            }
        }
    }
}
