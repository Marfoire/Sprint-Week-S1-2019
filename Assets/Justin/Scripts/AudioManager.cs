using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject soundPlayerPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySound(GameObject sender, AudioClip sound)
    {
        GameObject temp = Instantiate(soundPlayerPrefab, sender.transform.position, Quaternion.identity);
        AudioSource tempAs = temp.GetComponent<AudioSource>();

        tempAs.clip = sound;
        tempAs.Play();
    }


}
