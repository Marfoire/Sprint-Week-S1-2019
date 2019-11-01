using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60;

    public float timeLeft = 0;
    private bool running = false;

    public void StartTimer()
    {
        running = true;
        timeLeft = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                running = false;
                UIManager.uiManager.EndUi();
            }

        }

    }
}
