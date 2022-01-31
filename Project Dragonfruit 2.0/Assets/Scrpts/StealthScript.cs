using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthScript : MonoBehaviour
{
    public bool isHidden = false;
    public float resetval = 10;
    public float timer;
    public static StealthScript Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        timer = resetval;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHidden == false)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                
            }
            else
            {
                HUDScript.Instance.stressLVL += HUDScript.Instance.addAmount1;
                timer = resetval;
            }

        }
        else
        {
            timer = resetval;
        }
    }
}
