using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator UIAnim;
    public GameObject hurtParticles;

    public void Kill()
    {
        if (GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().state == GameState.Running)
        {
            GameObject newParticles = Instantiate(hurtParticles);
            newParticles.transform.position = transform.position;
            gameObject.GetComponent<PlayerMovement>().SetAlive(false);
            GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().state = GameState.Finished;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().RecordScore();
            UIAnim.Play("UIGameOver");
            Camera.main.GetComponent<Animator>().Play("CameraShake");
        }
    }
}
