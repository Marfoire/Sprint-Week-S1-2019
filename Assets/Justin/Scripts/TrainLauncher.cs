using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainLauncher : MonoBehaviour
{
    public float launchRate = 5;
    public float trainSpeed = 10;
   

    public Transform trainSpawnPoint;
    public float trainMaxXOffset; 

    public GameObject trainPrefab;

    private float trainTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        if(trainTimer <= 0)
        {
            GameObject tempTrain = Instantiate(trainPrefab, trainSpawnPoint.position, Quaternion.Euler(0,90,0));
            MoveStraight tempMs = tempTrain.GetComponent<MoveStraight>();
            tempMs.moveSpeed = trainSpeed;
            tempMs.maxXOffset = trainMaxXOffset;


            trainTimer = launchRate;
        }
        else
        {
            trainTimer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 140, 0);
        Gizmos.DrawLine(trainSpawnPoint.position, trainSpawnPoint.position + new Vector3(trainSpawnPoint.position.x + trainMaxXOffset, 0, 0));
        Gizmos.color = Color.white;
    }
}
