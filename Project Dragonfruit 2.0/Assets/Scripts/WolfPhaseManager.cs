using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfPhaseManager : MonoBehaviour
{
    public GameObject Phase2WolfEntity;
    public GameObject Phase4WolfHitbox;
    public GameObject Phase3WolfEntity;
    public Animator anim;
    private bool b1 = false;
    private bool b2 = false;
    private bool b3 = false;
    private bool b4 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HUDScript.Instance.stressLVL ==0f && HUDScript.Instance.stressLVL <= 25f && b4==false)
        {
            StealthScript.Instance.resetval = 2f;
            b4 = true;

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
            
        }

        if (WolfMouth1.Instance.caughtplr == true && WolfMouth1.Instance.kill == false)
        {
            Debug.Log("Caught!");
            anim.SetTrigger("Caught");
            anim.SetTrigger("Caught");

            //SceneManager.LoadScene("DeathScreen");
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Outwards"))
        {
            WolfMouth1.Instance.kill = true;
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
