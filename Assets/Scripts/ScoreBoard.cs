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
        m_blueScore = 0;
        m_redScore  = 0;
    }

    #region BlueTeamScore
    public void IncreaseBlueTeamScore(int p_amount)
    {
        m_blueScore += p_amount;
        m_blueTeamScoreText.text = m_blueScore.ToString();
    }
    #endregion

    #region RedTeamScore
    public void IncreaseRedTeamScore(int p_amount)
    {
        m_redScore += p_amount;
        m_redTeamScoreText.text = m_redScore.ToString();

    }
    #endregion

}
