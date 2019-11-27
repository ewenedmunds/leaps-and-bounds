using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState { Title, Running, Paused, Finished }

public class GameManager : MonoBehaviour
{
    float gameTimer;

    public float boundSpeed;
    public float maxBoundDistance;

    public GameObject leftBound;
    public GameObject rightBound;

    public GameState state = GameState.Title;

    private float score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

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

            ScoreBehaviour();

        }
    }

    public void StartGame()
    {
        state = GameState.Running;
    }

    public void AddScore(int amount)
    {
        if (amount >= 0)
        {
            score += amount;
        }
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

    void ScoreBehaviour()
    {
        score += Time.deltaTime*100;
        scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }
}
