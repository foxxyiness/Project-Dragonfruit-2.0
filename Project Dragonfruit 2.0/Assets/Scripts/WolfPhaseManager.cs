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
    private bool b5 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HUDScript.Instance.stressLVL ==0f && HUDScript.Instance.stressLVL < 25f && b4==false)
        {
            StealthScript.Instance.resetval = 2f;
            b4 = true;
            b1 = false;
            b2 = false;
            b3 = false;
            Phase2WolfEntity.SetActive(!b4);

        }
        if (HUDScript.Instance.stressLVL > 25f && HUDScript.Instance.stressLVL <= 50f && b1 == false)
        {
            b1 = true;
            b2 = false;
            b3 = false;
            b4 = false;
            Phase2WolfEntity.SetActive(b1);
            Phase3WolfEntity.SetActive(!b1);
            Phase4WolfHitbox.SetActive(!b1);
            StealthScript.Instance.resetval = 1.5f;
        }
        if (HUDScript.Instance.stressLVL > 50f && HUDScript.Instance.stressLVL <= 75f && b2 == false)
        {
            b1 = false;
            b2 = true;
            b3 = false;
            b4 = false;
            Phase2WolfEntity.SetActive(!b2);
            Phase3WolfEntity.SetActive(b2);
            Phase4WolfHitbox.SetActive(!b2);
            anim.Play("Entry");
            StealthScript.Instance.resetval = 1f;
            SoundManager.Instance.blist[7] = true;
        }
        if (HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f && b3 == false)
        {
            b1 = false;
            b2 = false;
            b3 = true;
            b4 = false;
            Debug.Log("Speed up!");
            anim.SetFloat("SpeedMult", 2);
            Phase3WolfEntity.SetActive(b3);
            Phase4WolfHitbox.SetActive(b3);
            StealthScript.Instance.resetval = 0.5f;
            SoundManager.Instance.blist[8] = true;

        }

        if (WolfMouth1.Instance.caughtplr == true && WolfMouth1.Instance.kill == false && b5 == false)
        {
            Debug.Log("Caught!");
            anim.SetTrigger("Caught");
            anim.SetTrigger("Caught");
            b5 = true;

            //SceneManager.LoadScene("DeathScreen");
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Outwards"))
        {
            WolfMouth1.Instance.kill = true;
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
