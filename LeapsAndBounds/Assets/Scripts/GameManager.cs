using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool isRunning;

    float gameTimer;

    public float boundSpeed;
    public float maxBoundDistance;

    public GameObject leftBound;
    public GameObject rightBound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        BoundBehaviour();


    }

    void BoundBehaviour()
    {
        float boundDistance = Mathf.Min(gameTimer * boundSpeed,maxBoundDistance);
        leftBound.transform.position = new Vector3(-19+boundDistance, 0);
        rightBound.transform.position = new Vector3(19-boundDistance, 0);
    }
}
