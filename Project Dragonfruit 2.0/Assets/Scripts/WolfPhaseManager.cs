using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPhaseManager : MonoBehaviour
{
    public GameObject Phase2WolfEntity;
    public GameObject Phase4WolfHitbox;
    public GameObject Phase3WolfEntity;
    public Animator anim;
    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HUDScript.Instance.stressLVL >=0f && HUDScript.Instance.stressLVL <= 25f)
        {
            StealthScript.Instance.resetval = 2f;

        }
        if (HUDScript.Instance.stressLVL > 25f && HUDScript.Instance.stressLVL <= 50f && b1 == false)
        {
            b1 = true;
            Phase2WolfEntity.SetActive(b1);
            StealthScript.Instance.resetval = 1.5f;
        }
        if (HUDScript.Instance.stressLVL > 50f && HUDScript.Instance.stressLVL <= 75f && b2 == false)
        {
            b2 = true;
            Phase2WolfEntity.SetActive(!b2);
            Phase3WolfEntity.SetActive(b2);
            anim.Play("Entry");
            StealthScript.Instance.resetval = 1f;
        }
        if (HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f && b3 == false)
        {
            b3 = true;
            Debug.Log("Speed up!");
            anim.SetFloat("SpeedMult", 2);
            Phase3WolfEntity.SetActive(b3);
            Phase4WolfHitbox.SetActive(b3);
            StealthScript.Instance.resetval = 0.5f;
            if (WolfMouth1.Instance.caughtplr == true)
            {
                Debug.Log("Caught!");
                anim.SetTrigger("Caught");
                anim.SetTrigger("Caught");
            }
        }
        

    }
}
