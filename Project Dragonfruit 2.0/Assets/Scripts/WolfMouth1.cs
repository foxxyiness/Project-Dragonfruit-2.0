using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMouth1 : MonoBehaviour
{
    public string goodytagname;
    public static bool caughtplr = false;
    public static bool distracted = false;
    public GameObject DisTarget;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        void OnTriggerEnter2D(Collider2D coll)
        {
            if(caughtplr == false)
            {
                caughtplr = true;
            }


        }
    }

}