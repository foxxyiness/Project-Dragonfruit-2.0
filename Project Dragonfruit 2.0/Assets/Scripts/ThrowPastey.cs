using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPastey : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;
    private Rigidbody2D RB2D;
    public PlayerStateMachine PSM;

    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        if (Thrown && (PSM.faceRight ==true))
        {
            var direction = -transform.right + Vector3.up;
            RB2D.AddForce(direction * Speed, ForceMode2D.Impulse);
            Debug.Log("Thrown Left");
            Thrown = false;
        }
        else if (Thrown && (PSM.faceRight == false))
        {
            var direction = transform.right + Vector3.up;
            RB2D.AddForce(direction * Speed, ForceMode2D.Impulse);
            Debug.Log("Thrown Right");
            Thrown = false;
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

}
