using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public float HeartSpeed;
    public Animator anim;
    public float timer = 0;
    public float buffertime = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HUDScript.Instance.stressLVL == 0f && HUDScript.Instance.stressLVL <= 25f)
        {
            buffertime = 2f;
            HeartSpeed = 0.5f;
        }
        if (HUDScript.Instance.stressLVL > 25f && HUDScript.Instance.stressLVL <= 50f)
        {
            buffertime = 1.5f;
            HeartSpeed = 1f;
        }
        if (HUDScript.Instance.stressLVL > 50f && HUDScript.Instance.stressLVL <= 75f)
        {
            buffertime = 1f;
            HeartSpeed = 1.5f;
        }
        if (HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f)
        {
            buffertime = 0.5f;
            HeartSpeed = 2f;
        }
        anim.SetFloat("Speed", HeartSpeed);
        timer += Time.deltaTime;
        if(timer >= buffertime)
        {
            anim.Play("Entry");
            SoundManager.Instance.blist[2] = true;
            timer = 0;
        }
    }
}
