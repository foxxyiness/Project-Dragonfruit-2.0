using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfChaseTrigger : MonoBehaviour
{
    private bool finale = false;
    private bool musicplaying = false;
    private float windtimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (finale && musicplaying == false)
        {
            HUDScript.Instance.stressLVL = 80f;
            SoundManager.Instance.blist[9] = true;
            musicplaying = true;
        }
        if(windtimer == 0)
        {
            SoundManager.Instance.blist[0] = true;
        }

        if (windtimer <=53.808f)
        {
            windtimer += Time.deltaTime;
        }
        else if (windtimer >= 53.808f)
        {
            windtimer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (finale = false)
            {
                finale = true;
            }

            Debug.Log("Running Sequence activated");
        }
    }
}
