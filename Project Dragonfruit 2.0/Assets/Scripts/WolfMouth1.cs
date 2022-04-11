using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMouth1 : MonoBehaviour
{
    public bool caughtplr = false;
    public bool kill = false;
    public bool eat = false;
    public bool distracted = false;
    public GameObject DisTarget;
    public static WolfMouth1 Instance;
    public float Stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (eat == true)
        {
            Stopwatch += Time.deltaTime;
        }
        if (Stopwatch > 3f)
        {
            eat = false;
            distracted = false;
            Stopwatch = 0f;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Goody")
        {
            DisTarget = coll.gameObject;
            eat = true;
            Destroy(DisTarget);
        }
        if (coll.gameObject.tag == "Player" && distracted == false && StealthScript.Instance.isHidden == false)
        {
            caughtplr = true;
            Debug.Log("Player caught by hitbox");
            SoundManager.Instance.blist[6] = true;
        }
    }
}
