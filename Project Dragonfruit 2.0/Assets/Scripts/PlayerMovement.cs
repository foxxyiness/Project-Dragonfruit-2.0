using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Light Stuff")]
    public GameObject latern;
    public Sprite laternSprite;
    [Header("Crouch Stuff")]
    public SpriteRenderer SpriteRenderer;
    public Sprite standing;
    public Sprite crouching;
    public CapsuleCollider2D Collider;
    public Vector2 StandingSize;
    public Vector2 CrouchingSize;
   
    [Header("Player Speed and Stuff")]
    public float speed = 200f;
    public float movement;
    public int powerJump = 200;
    public float sprintSpeed;

    [Header("Impotant Bools")]
    public bool faceRight;
    public bool isCrouching;
    public bool isGrounded;
    public bool isSprinting;
    public bool toggleLight;

   
    public void PlayerMove()
    {
        Collider.size = StandingSize;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = standing;
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }

        if (Input.GetButton("Sprint") && (isSprinting == false && isGrounded == true))
        {
            Sprint();
        }
        else
        {
            speed = 200f;
            isSprinting = false;
        }

        if (movement < 0.0f && faceRight == false)
        {
            FlipPlayer();
        }
        else if (movement > 0.0f && faceRight == true)
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        //Crouching
        if(Input.GetButton("Crouch") && (isSprinting == false && isGrounded == true))
        {
            LightOff();
            SpriteRenderer.sprite = crouching;
            Collider.size = CrouchingSize;
            isCrouching = true;
        }
        else
        {
            SpriteRenderer.sprite = standing;
            Collider.size = StandingSize;
            isCrouching = false;
        } 

        //Enabling Light
        if(Input.GetButtonDown("Light") && (toggleLight == false && isCrouching == false))
        {
            LightOn();
        }
        else if(Input.GetButtonDown("Light") && (toggleLight == true && isCrouching == false))
        {
            LightOff();
            SpriteRenderer.sprite = standing;
        }

        if(toggleLight == true)
        {
            SpriteRenderer.sprite = laternSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //Sprint Function
    public void Sprint()
    {
        speed += sprintSpeed;
        isSprinting = true;
    }
    //Enable Light
    public void LightOn()
    {
        toggleLight = true;
        latern.SetActive(true);
    }
    public void LightOff()
    {
        toggleLight = false;
        latern.SetActive(false);
    }
    //Jump Function
    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * powerJump);
        isGrounded = false;
    }

    //Currenting allowing player to flip side until animations
    public void FlipPlayer()
    {
        faceRight = !faceRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    //Collider for player to detect ground
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}

