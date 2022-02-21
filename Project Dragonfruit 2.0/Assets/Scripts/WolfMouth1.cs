using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMouth1 : MonoBehaviour
{
    public string goodytagname;
    public bool caughtplr = false;
    public bool distracted = false;
    public GameObject DisTarget;
    public static WolfMouth1 Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        void OnTriggerEnter2D(Collider2D coll)
        {
<<<<<<< HEAD
            if(caughtplr == false)
            {
                caughtplr = true;
            }


=======
            caughtplr = true;
>>>>>>> parent of 1fdd101 (Compiler updates)
        }
    }

}
