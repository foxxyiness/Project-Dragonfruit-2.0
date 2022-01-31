using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBehind : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StealthScript.Instance.isHidden = true;
            Debug.Log("Hiding!");
        }
        
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StealthScript.Instance.isHidden = false;
            Debug.Log("Not Hiding!");
        }

    }
}
