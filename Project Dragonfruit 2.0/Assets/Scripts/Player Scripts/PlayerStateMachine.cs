using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateMachine : MonoBehaviour
{
    public Animator Animator;
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
    public Rigidbody2D rb;
    public float speed = 300f;
    public float movement;
    public float powerJump = 5.0f;
    public float sprintSpeed = 1.0f;
    public Vector2 move; 

    [Header("Impotant Bools")]
    public bool faceRight;
    public bool isCrouching;
    public bool isGrounded;
    public bool isJumpPressed = false;
    public bool isSprinting = false;
    public bool isMoving = false;
    public bool lightOn = false;
    public bool canMove = true;

    PlayerBaseState _currentState;
    PlayerStateFactory _states;
    Lantern_Decay lanternStuff;

    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public bool isSprintPressed { get { return isSprinting; } }
    public bool isMovementPressed { get { return isMoving; } }
    public bool isCrouchedPressed { get { return isCrouching; } }
    public bool isLightOn { get { return lightOn; } }
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
        rb.velocity = new Vector2(move.x * speed * sprintSpeed * Time.deltaTime, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Current State " +_currentState);
        IsJumpPressed();
       // IsLanternJumpPressed();
        IsSprintPressed();
        IsMovementPressed();
        IsCrouchedPressed();
        IsLightPressed();
        _currentState.UpdateStates();

        if (canMove)
            move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        


    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            rb.velocity = Vector2.up * 0;
            Animator.SetBool("isJumping", false);
        }
        if (col.gameObject.tag == "Victory")
        {
            SceneManager.LoadScene("VictoryScreen");
        }
        if (col.gameObject.tag == "Death")
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
   

    void IsJumpPressed()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumpPressed = true;
            Debug.Log("Jump Pressed");
        }
        else { isJumpPressed = false; }
    }
   
    void IsSprintPressed()
    {

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
    void IsMovementPressed()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            Debug.Log("Movement Pressed");
        }
        else
            isMoving = false;

        if (move.x < 0.0f && faceRight == false)
        {
            FlipPlayer();
        }
        else if (move.x > 0.0f && faceRight == true)
        {
            FlipPlayer();
        }
    }

    void IsCrouchedPressed()
    {
        if(Input.GetKey(KeyCode.LeftControl) && isGrounded)
        {
            isCrouching = true;
            Debug.Log("Crouched Pressed");
        }
        else
        {
            isCrouching = false;
        }
    }
    void IsLightPressed()
    {
        if(!lightOn && Input.GetKeyDown(KeyCode.F) && isGrounded && !isCrouching)
        {
            lightOn = true;
            latern.SetActive(true);
            Debug.Log("Light On");
        }
        else if(lightOn && Input.GetKeyDown(KeyCode.F) && isGrounded && !isCrouching)
        {
            lightOn = false;
            latern.SetActive(false);
            Debug.Log("Light Off");
        }
    }
    public void FlipPlayer()
    {
        faceRight = !faceRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void PauseFrameJump()
    {
        Animator.speed = 0.0f;
    }

}
