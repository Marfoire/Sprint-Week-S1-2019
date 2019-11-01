using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour
{
    private AudioSource musics;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        musics = GetComponent<AudioSource>();
    }

    /*void Start()
    {
        SceneManager.LoadScene("Bullet Hell Stage", LoadSceneMode.Single);
    }*/
}
