using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour
{
    public Sprite hitSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().Kill();
            if (hitSprite != null)
            {
                GetComponent<SpriteRenderer>().sprite = hitSprite;
            }
        }
    }
}
