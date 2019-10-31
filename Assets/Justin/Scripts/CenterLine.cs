using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterLine : MonoBehaviour
{
    public int playerScore = 0;
    public int enemyScore = 0;

    private void Start()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach(GameObject i in balls)
        {
            int side = i.GetComponent<BallSide>().side;
            if (side == 1)
            {
                playerScore++;
            }
            else if (side == -1)
            {
                enemyScore++;
            }
        }
    }

    private void Update()
    {
        UIManager.uiManager.setScore(playerScore);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Ball Crossing!");
        if(collision.gameObject.tag == "Ball")
        {
            BallSide sideScript = collision.gameObject.GetComponent<BallSide>();
            int side = sideScript.side;            

            if (side == 1)
            {
                playerScore--;
                enemyScore++;
            }
            else if (side == -1)
            {
                enemyScore--;
                playerScore++;
            }

            sideScript.side *= -1;
        }
    }
}
