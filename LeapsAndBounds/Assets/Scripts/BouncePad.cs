using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("BouncePad");
            transform.parent.gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
