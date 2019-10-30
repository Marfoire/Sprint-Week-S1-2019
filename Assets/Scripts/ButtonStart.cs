using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public Button btnStart;

    void Start()
    {
        Button btn = btnStart.GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
    }


    void StartGame() {
        //Load gameplay scene
        SceneManager.LoadScene("Bullet Hell Stage");
    }
}
