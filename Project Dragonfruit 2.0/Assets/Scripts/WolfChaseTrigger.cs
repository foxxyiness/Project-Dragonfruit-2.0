using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfChaseTrigger : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
           
        }
    }
}
