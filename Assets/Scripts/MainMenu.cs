using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region scenemanager
    // Loading scenes/quit functions
    public void Play()
    {
        SceneManager.LoadScene("Bullet Hell Stage", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls", LoadSceneMode.Single);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
    #endregion
}
