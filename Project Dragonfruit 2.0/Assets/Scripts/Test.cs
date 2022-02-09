using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //[Header("Player Speed")]
    //public Vector3 jump, movement;
    //public float speed;
    //public float runSpeed;
    //public float jumpForce = 2.0f;
    //public float gravityScale = 5;

    //[Header("Player Actions")]
    //public bool isGrounded;
    //public bool isSprinting;
    //public Rigidbody2D rb;
    //void Start()
    //{

    //    rb = GetComponent<Rigidbody2D>();
    //    jump = new Vector3(0.0f, 2.0f, 0.0f);

    //}

    //private void FixedUpdate()
    //{
    //    rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    //}
    //void OnCollisionEnter()
    //{
    //    isGrounded = true;
    //}

    //void Update()
    //{
    //    rb.velocity = movement;
    //    float horizontalMovement = Input.GetAxis("Horizontal");
    //    movement = new Vector3(speed * Time.deltaTime * horizontalMovement, 0, 0);

    //    //*******FIXED LATER CANT SPRINT AND JUMP WITHOUT BEING SUPERMAN*******
    //    if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isSprinting == false)
    //    {

    //        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //        isGrounded = false;
    //    }
    //    /****************************************************************************************/
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        isSprinting = true;
    //    }
    //    else
    //    {
    //        isSprinting = false;
    //    }

    //    if (isSprinting == true)
    //    {
    //        rb.AddForce(movement * runSpeed, ForceMode.Impulse);
    //    }

    //}
}
