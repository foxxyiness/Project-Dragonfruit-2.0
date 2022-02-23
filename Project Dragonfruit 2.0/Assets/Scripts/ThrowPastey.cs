using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPastey : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;
    public Rigidbody2D RB2D;

    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        if (Thrown && (PlayerMovement.faceRight == true))
        {
            var direction = -transform.right + Vector3.up;
            RB2D.AddForce(direction * Speed, ForceMode2D.Impulse);
        }
        else if (Thrown && (PlayerMovement.faceRight == false))
        {
            var direction = transform.right + Vector3.up;
            RB2D.AddForce(direction * Speed, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag =="Ground")
        {
            RB2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            RB2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
