using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSprite : MonoBehaviour
{
    public float timer;
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, timer*3);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
