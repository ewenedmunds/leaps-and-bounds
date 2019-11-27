using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator UIAnim;

    public void Kill()
    {
        gameObject.GetComponent<PlayerMovement>().SetAlive(false);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().state = GameState.Finished;
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().RecordScore();
        UIAnim.Play("UIGameOver");
        
    }
}
