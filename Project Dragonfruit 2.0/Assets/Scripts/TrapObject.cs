using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObject : MonoBehaviour
{
    public float pointsadded;
    private float timer = 0;
    public float timedestroy = 2;
    public bool isdestructible;
    private bool activated = false;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isdestructible == true)
        {
            if (activated == true)
            {
                timer += Time.deltaTime;
            }
            if (timer >= timedestroy)
            {
                Destroy(parent);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && activated == false)
        {
            HUDScript.Instance.stressLVL += pointsadded;
            activated = true;
            Debug.Log("Trap Activated");
        }
        if (coll.gameObject.tag == "Player" && isdestructible == false)
        {
            HUDScript.Instance.stressLVL += pointsadded;
            Debug.Log("Trap Activated");
        }

    }
}
