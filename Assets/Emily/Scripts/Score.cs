using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public Transform ball;
    public Text points;
    public static int scoreValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        points.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Score:" + scoreValue;
    }
}


