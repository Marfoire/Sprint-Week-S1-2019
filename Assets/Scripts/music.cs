using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    #region music
    // Play music
    private AudioSource musics;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        musics = GetComponent<AudioSource>();
    }
    #endregion
}
