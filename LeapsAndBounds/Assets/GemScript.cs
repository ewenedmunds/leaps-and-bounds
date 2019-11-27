using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public GameObject particles;
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().AddScore(value);
            if (particles != null)
            {
                GameObject newParticles = Instantiate(particles, transform.parent.parent);
                newParticles.transform.position = transform.position;
            }

            Destroy(gameObject);
        }
    }
}
