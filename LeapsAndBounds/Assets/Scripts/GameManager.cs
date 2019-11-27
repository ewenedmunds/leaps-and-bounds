using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Title, Running, Paused, Finished }

public class GameManager : MonoBehaviour
{
    float gameTimer;

    public float boundSpeed;
    public float maxBoundDistance;

    public GameObject leftBound;
    public GameObject rightBound;

    public GameState state = GameState.Title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Running)
        {
            gameTimer += Time.deltaTime;
            BoundBehaviour();

        }
    }

    public void StartGame()
    {
        state = GameState.Running;
    }

    void BoundBehaviour()
    {
        if (gameTimer >= 5)
        {
            float boundDistance = Mathf.Min((gameTimer-5) * boundSpeed, maxBoundDistance);
            leftBound.transform.position = new Vector3(-16.5f + boundDistance, 0);
            rightBound.transform.position = new Vector3(16.5f - boundDistance, 0);
        }
    }
}
