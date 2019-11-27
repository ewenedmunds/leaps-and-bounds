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

    public GameObject[] terrainPieces;

    // Update is called once per frame
    void Update()
    {
        if (manager.state == GameState.Running)
        {
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
        GameObject newTerrain = Instantiate(terrainPieces[Random.Range(0, terrainPieces.Length)],terrainHolder.transform);


    }
}
