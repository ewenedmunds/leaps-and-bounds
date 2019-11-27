using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void Kill()
    {
        gameObject.GetComponent<PlayerMovement>().SetAlive(false);
    }
}
