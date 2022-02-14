using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStateMachine : MonoBehaviour
{
    [Header("Pastry Throw Stuff")]
    public ThrowPastey Pastry;


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
    public float speed = 300f;
    public float movement;
    public int powerJump = 200;
    public float sprintSpeed;

    [Header("Impotant Bools")]
    static public bool faceRight;
    public bool isCrouching;
    public bool isGrounded;
    public bool isSprinting;
    public bool toggleLight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
