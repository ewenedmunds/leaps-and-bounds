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

    private bool isAlive = true;

    public Sprite spriteMoveR;
    public Sprite spriteMoveL;
    public Sprite spriteJump;
    public Sprite spriteDead;
    public Sprite spriteNormal;

    public GameObject jumpGhost;

    public SpriteRenderer sr;

    private float coyoteTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            MovementInputs();
        }
        PassiveMovement();

        transform.position += new Vector3(velX, velY) * Time.deltaTime;

    }

    public void SetAlive(bool value)
    {
        isAlive = value;
        sr.sprite = spriteDead;
    }

    void MovementInputs()
    {
        int sprintMod = 1;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            sprintMod = 3;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            velX -= accX * Time.deltaTime * sprintMod;
            if (isAlive)
            {
                sr.sprite = spriteMoveL;
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            velX += accX * Time.deltaTime * sprintMod;
            if (isAlive)
            {
                sr.sprite = spriteMoveR;
            }

        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!IsGrounded())
            {
                velY -= 6*Time.deltaTime;
            }
        }

        velX = Mathf.Min(Mathf.Abs(velX), maxX) * Mathf.Sign(velX);

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
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
                if (Physics2D.Raycast(transform.position + new Vector3(0, (i * 0.22f)), Vector2.right, 0.325f, groundLayers).collider != null)
                {
                    velX = 0;
                }
            }
            else if (velX < 0)
            {
                if (Physics2D.Raycast(transform.position + new Vector3(0, (i * 0.22f)), Vector2.left, 0.325f, groundLayers).collider != null)
                {
                    velX = 0;
                }
            }
        }

        //Gravity
        if (!IsGrounded())
        {
            coyoteTime -= Time.deltaTime;
            velY += accY * Time.deltaTime;
            if (velY <= 0)
            {
                velY = Mathf.Max(velY, maxY);
            }
            GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            coyoteTime = 0.15f;
            if (velY < 0)
            {
                if (velY < -3)
                {
                    sr.gameObject.GetComponent<Animator>().Play("PlayerSquish");
                }
                velY = 0;
            }
            if (Mathf.Abs(velX) < 0.2f && isAlive)
            {
                sr.sprite = spriteNormal;
            }
            if (Mathf.Abs(velX) > 2 && !GetComponent<ParticleSystem>().isPlaying)
            {
                GetComponent<ParticleSystem>().Play();
            }
            else if (Mathf.Abs(velX) <= 2)
            {
                GetComponent<ParticleSystem>().Stop();
            }
        }

        if (velY > 0)
        {
            if (isAlive)
            {
                sr.sprite = spriteJump;
            }
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
        if (coyoteTime > 0 && velY < 5)
        {
            velY = jumpVel;
            coyoteTime = 0;
            GetComponent<AudioSource>().Play();
        }


    }

    public void BouncePad()
    {

        velY = jumpVel*1.5f;
        StartCoroutine("Ghosts");
        GetComponent<AudioSource>().Play();

        if (Random.Range(1,3) == 1 && isAlive)
        {
            sr.gameObject.GetComponent<Animator>().Play("PlayerSpriteSpinL");
        }
        else if (isAlive)
        {
            sr.gameObject.GetComponent<Animator>().Play("PlayerSpriteSpinR");
        }
    }

    IEnumerator Ghosts()
    {
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
        yield return new WaitForSeconds(0.05f);
        CreateGhost();
    }

    void CreateGhost()
    {
        GameObject newGhost = Instantiate(jumpGhost);
        newGhost.transform.position = transform.position;
        newGhost.transform.parent = transform.parent;
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
