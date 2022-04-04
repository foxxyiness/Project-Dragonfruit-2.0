using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthScript : MonoBehaviour
{
    public bool isHidden = false;
    public float resetval = 1.5f;
    public float timer;
    public static StealthScript Instance;
    private PlayerStateMachine PSM;
    private GameObject Player;
    public bool heartbeat = false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        timer = resetval;
        Player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isHidden == false && resetval <= 1 && Player.GetComponent<PlayerStateMachine>().lightOn == false)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;

            }
            else
            {
                HUDScript.Instance.stressLVL += HUDScript.Instance.addAmount1;

                timer = resetval;
            }

        }
        else if (isHidden == false && resetval <= 1 && Player.GetComponent<PlayerStateMachine>().lightOn == false)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;

            }
            else
            {
                HUDScript.Instance.stressLVL += HUDScript.Instance.addAmount2;
                HUDScript.Instance.addAmount2 += 1;

                timer = resetval;
            }
        }
        else if (isHidden == true && Player.GetComponent<PlayerStateMachine>().lightOn == false)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;

            }
            else
            {
                HUDScript.Instance.stressLVL -= HUDScript.Instance.subAmount;

                timer = resetval;
            }

        }
        else if(isHidden == false && Player.GetComponent<PlayerStateMachine>().lightOn == true)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;

            }
            else
            {
                HUDScript.Instance.stressLVL += 1;

                timer = resetval;
            }
        }



        else
        {
            timer = resetval;
        }
    }
}
