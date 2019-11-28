using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameManager manager;
    public GameObject terrainHolder;

    private float movementSpeed = 1;
    public float terrainAcceleration;
    public float terrainMaxSpeed;

    public GameObject[] terrainPiecesEasy;
    public GameObject[] terrainPiecesMedium;
    public GameObject[] terrainPiecesHard;

    private float timer;
    public int[] thresholds;

    // Update is called once per frame
    void Update()
    {
        if (manager.state == GameState.Running)
        {
            timer += Time.deltaTime;

            movementSpeed += terrainAcceleration*Time.deltaTime;
            movementSpeed = Mathf.Min(movementSpeed, terrainMaxSpeed);

            for (int i = 0; i < terrainHolder.transform.childCount; i++)
            {
                terrainHolder.transform.GetChild(i).transform.Translate(new Vector3(-movementSpeed, 0, 0) * Time.deltaTime);
            }
        }
    }

    public void NewTerrain()
    {
        Debug.Log("New Terrain Generating!");
        if (timer > thresholds[2] && Random.Range(0f, 2f) < 1f)
        {
            GameObject newTerrain = Instantiate(terrainPiecesHard[Random.Range(0, terrainPiecesHard.Length)], terrainHolder.transform);
        }
        else if (timer > thresholds[1] && Random.Range(0f, 2f) < 1f)
        {
            GameObject newTerrain = Instantiate(terrainPiecesMedium[Random.Range(0, terrainPiecesMedium.Length)], terrainHolder.transform);
        }
        else
        {
            GameObject newTerrain = Instantiate(terrainPiecesEasy[Random.Range(0, terrainPiecesEasy.Length)], terrainHolder.transform);
        }



    }
}
