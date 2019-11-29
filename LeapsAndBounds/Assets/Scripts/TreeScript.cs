using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float z = transform.position.z/10;
        GetComponent<SpriteRenderer>().color = new Color(1-z+Random.Range(-0.1f,0.1f), 1-z + Random.Range(-0.1f, 0.1f), 1-z + Random.Range(-0.1f, 0.1f));
        transform.localScale = new Vector3(Random.Range(0.5f, 1.3f), 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
