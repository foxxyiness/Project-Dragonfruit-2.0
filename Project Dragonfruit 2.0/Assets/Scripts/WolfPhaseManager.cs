using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfPhaseManager : MonoBehaviour
{
    public GameObject Phase2WolfEntity;
    public GameObject Phase4WolfHitbox;
    public GameObject Phase3WolfEntity;
    public GameObject ParticlePrefab;
    public Animator anim;
    private bool b1 = false;
    private bool b2 = false;
    private bool b3 = false;
    private bool b4 = false;
    private bool b5 = false;
    private bool b6 = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HUDScript.Instance.stressLVL >=0f && HUDScript.Instance.stressLVL < 25f && b4 == false)
        {

            if(b1)
            {
                Instantiate(ParticlePrefab, gameObject.transform.position, Quaternion.identity);
            }
            StealthScript.Instance.resetval = 2f;
            b4 = true;
            b1 = false;
            b2 = false;
            b3 = false;
            Phase2WolfEntity.SetActive(!b4);

        }
        if (HUDScript.Instance.stressLVL > 25f && HUDScript.Instance.stressLVL <= 50f && b1 == false)
        {
            Instantiate(ParticlePrefab, gameObject.transform.position, Quaternion.identity);
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
            Instantiate(ParticlePrefab, gameObject.transform.position, Quaternion.identity);
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
        if(GameObject.FindWithTag("Goody"))
        {
            if (b6 == false)
            {
                anim.SetTrigger("Sniffing");
                anim.SetTrigger("Sniffing");
                b6 = true;
            }
        }
        else
        {
            b6 = false;
        }


        if (HUDScript.Instance.stressLVL >= 75f && HUDScript.Instance.stressLVL <= 100f && b5 == false)
        {
            if (WolfMouth1.Instance.caughtplr == true)
            {
                Debug.Log("Caught!");
                anim.SetTrigger("Caught");
                anim.SetTrigger("Caught");
                b5 = true;
                GameObject.FindWithTag("Player").GetComponent<PlayerStateMachine>().canMove = false;
                SceneManager.LoadScene("DeathCutscene");
            }

        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Outwards"))
        {
            
            WolfMouth1.Instance.kill = true;
            while(timer<=5)
            {
                timer += Time.deltaTime;
            }
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
