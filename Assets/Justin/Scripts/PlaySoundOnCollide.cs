using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollide : MonoBehaviour
{
    public AudioClip clip;
    public float forceToPlay = 4;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >= forceToPlay)
        {
            AudioManager.instance.PlaySound(gameObject, clip);
        }
    }
}
