using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMusic : MonoBehaviour
{
    #region musicspawn
    // Spawn the music boc if there are no other music boxes currently playing
    public GameObject musical;

    void Start()
    {
        if (GameObject.Find("Music Box(Clone)") == null)
        {
            Instantiate(musical, transform.position, transform.rotation);
        }
    }
    #endregion
}
