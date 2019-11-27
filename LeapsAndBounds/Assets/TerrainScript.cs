using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    bool isAbleToGenerateExtraTerrain = true;
    float generateThreshold = 28;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 13 && isAbleToGenerateExtraTerrain)
        {
            Debug.Log("Terrain out of bounds");
            GameObject.FindGameObjectWithTag("TerrainManager").GetComponent<TerrainManager>().NewTerrain();
            isAbleToGenerateExtraTerrain = false;
        }

        if (transform.position.x <= -15)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
