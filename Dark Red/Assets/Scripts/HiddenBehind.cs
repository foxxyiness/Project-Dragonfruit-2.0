using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBehind : MonoBehaviour
{
    public PlayerStateMachine PSM;

    // Start is called before the first frame update
    void Start()
    {
        PSM = GameObject.FindWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && PSM.lightOn == false)
        {
            if (PSM.isCrouching == false)
            {
                StealthScript.Instance.isHidden = false;
                Debug.Log("Not Hiding!");
                SoundManager.Instance.blist[3] = true;
                HUDScript.Instance.stressLVL += 5;
            }
            else
            {
                StealthScript.Instance.isHidden = true;
                Debug.Log("Hiding!");
            }
        }
        
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && PSM.lightOn == false)
        {
            if (PSM.isCrouching == false)
            {
                StealthScript.Instance.isHidden = false;
                Debug.Log("Not Hiding!");
            }
            else
            {
                StealthScript.Instance.isHidden = true;
                Debug.Log("Hiding!");
            }
        }

    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StealthScript.Instance.isHidden = false;
            Debug.Log("Not Hiding!");
            if (PSM.isCrouching == false)
            {
                SoundManager.Instance.blist[3] = true;
                HUDScript.Instance.stressLVL += 5;
            }
        }

    }
}
