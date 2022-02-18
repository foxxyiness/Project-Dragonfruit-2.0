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
    public PolygonCollider2D Collider;
    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    [Header("Player Speed and Stuff")]
    public Rigidbody2D rb;
    public float speed = 300f;
    public float movement;
    public float powerJump = 200;
    public float sprintSpeed;
    public Vector2 move;

    [Header("Impotant Bools")]
    static public bool faceRight;
    public bool isCrouching;
    public bool isGrounded;
    public bool isJumpPressed = false;
    public bool isSprinting = false;
    public bool isMovementPressed = false;
    public bool toggleLight;

    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public bool isSprintPressed { get { return isSprinting; } }
  
    public bool groundCheck{ get { return isGrounded; } }
    //Awake is called earlier than Start
    void Awake()
    {
        _states = new PlayerStateFactory(this);
        _currentState = _states.GroundState();
        _currentState.EnterState();

        rb = GetComponent<Rigidbody2D>();
        
    }
    void Start()
    {
     
       
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        IsJumpPressed();
        IsSprintPressed();
        _currentState.UpdateStates();
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
   

    void IsJumpPressed()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumpPressed = true;
        }
        else { isJumpPressed = false; }
    }
    void IsSprintPressed()
    {

        if (Input.GetButton("Sprint") && isGrounded)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
    void IsMomementPressed()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            isMovementPressed = true;
        }

    }

}
