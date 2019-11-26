using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float velX;
    private float velY;

    public float decelerationX;
    public float jumpVel;

    public float accX;
    public float accY;

    public float maxX;
    public float maxY;

    public LayerMask groundLayers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();
        PassiveMovement();

        transform.position += new Vector3(velX, velY) * Time.deltaTime;

    }

    void MovementInputs()
    {
        int sprintMod = 1;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            sprintMod = 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            velX -= accX * Time.deltaTime * sprintMod;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velX += accX * Time.deltaTime * sprintMod;
        }

        velX = Mathf.Min(Mathf.Abs(velX), maxX) * Mathf.Sign(velX);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void PassiveMovement()
    {
        //Deceleration
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            velX += Time.deltaTime * Mathf.Sign(velX) * decelerationX;

            if (Mathf.Abs(velX) < 0.35f)
            {
                velX = 0;
            }
        }

        for (int i = -1; i < 1; i++)
        {
            if (velX > 0)
            {
                if (Physics2D.Raycast(transform.position + new Vector3(0, (i * 0.25f)), Vector2.right, 0.325f, groundLayers).collider != null)
                {
                    velX = 0;
                }
            }
            else if (velX < 0)
            {
                if (Physics2D.Raycast(transform.position + new Vector3(0, (i * 0.25f)), Vector2.left, 0.325f, groundLayers).collider != null)
                {
                    velX = 0;
                }
            }
        }

        //Gravity
        if (!IsGrounded())
        {
            velY += accY * Time.deltaTime;
            if (velY <= 0)
            {
                velY = Mathf.Max(velY, maxY);
            }
        }
        else
        {
            if (velY < 0)
            {
                velY = 0;
            }
        }

        if (velY > 0)
        {
            for (int i = -1; i < 1; i++)
            {
                if (Physics2D.Raycast(transform.position + new Vector3((i * 0.3f), 0), Vector2.up, 0.33f, groundLayers).collider != null)
                {
                    velY = 0;
                }
            }
        }
    }

    void Jump()
    {
        if (IsGrounded())
        {
            velY = jumpVel;
        }
    }

    public void BouncePad()
    {

        velY = jumpVel;


    }

    bool IsGrounded()
    {
        for (int i = -1; i <= 1; i++)
        {
            if (Physics2D.Raycast(transform.position + new Vector3((i * 0.3f), 0), Vector2.down, 0.33f, groundLayers).collider != null)
            {
                return true;
            }
        }
        return false;
    }
}
