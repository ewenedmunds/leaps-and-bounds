using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomiser : MonoBehaviour
{

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];  
    }

}
