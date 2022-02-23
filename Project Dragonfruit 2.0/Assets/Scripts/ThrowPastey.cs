using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPastey : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;

    void Start()
    {
        if (Thrown && (PlayerMovement.faceRight == true))
        {
            var direction = -transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
        }
        else if (Thrown && (PlayerMovement.faceRight == false))
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
