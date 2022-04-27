using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyTracking : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public GameObject body;
    public GameObject ParticlePrefab;
    public Vector3 CurrPos;
    public Vector3 BodyPos;
    public float speed = 1f;
    float startspeed;
    public bool faceRight = false;
    public PlayerStateMachine PSM;
    public float yoffset = 1f;
    public float xoffsetspawn = 20f;
    public bool spawn;
    public float stomping = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startspeed = speed;
        target = player;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Goody"))
        { 
            target = GameObject.FindWithTag("Goody");
            if(HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f)
            {
                WolfMouth1.Instance.distracted = true;
            }
        }
        else
        {
            target = player;
        }
        
        BodyPos = body.transform.position;
        BodyPos.z = body.transform.position.z;
        BodyPos.y += yoffset;
        if (HUDScript.Instance.stressLVL >= 75f && HUDScript.Instance.stressLVL <= 100f)
        {
            if (spawn == false)
            {
                Instantiate(ParticlePrefab, gameObject.transform.position, Quaternion.identity);
                transform.position = new Vector3(transform.position.x-xoffsetspawn , transform.position.y, transform.position.z);
                Debug.Log("Wolf pushed back");
            }
            spawn = true;
        }
        
        else if (HUDScript.Instance.stressLVL >= 0f && HUDScript.Instance.stressLVL < 25f)
        {
            if(spawn)
            {
                transform.position = new Vector3(transform.position.x - xoffsetspawn, transform.position.y, transform.position.z);
            }
            spawn = false;
        }
        CurrPos = target.transform.position;
        CurrPos.z = body.transform.position.z;
        if (PSM.isGrounded == true)
            CurrPos.y += yoffset;
        else
            CurrPos.y = body.transform.position.y;
        float steptoward = speed * Time.deltaTime;
        if ((body.transform.localPosition.x - CurrPos.x) < 0 && faceRight)
        {
            faceRight = !faceRight;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        else if ((body.transform.localPosition.x - CurrPos.x) > 0 && !faceRight)
        {
            faceRight = !faceRight;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        
        if (target == player)
        { 
            if (StealthScript.Instance.isHidden == false && (HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f) == false)
            {
                body.transform.localPosition = Vector3.MoveTowards(body.transform.localPosition, CurrPos, steptoward);
            } 
            else if(HUDScript.Instance.stressLVL >= 75f && HUDScript.Instance.stressLVL <= 100f)
            {
                if(WolfMouth1.Instance.distracted == false && WolfMouth1.Instance.caughtplr == false)
                    body.transform.localPosition = Vector3.MoveTowards(body.transform.localPosition, CurrPos, steptoward);
                
                if (WolfMouth1.Instance.caughtplr == true)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                }
            }
        }
        else if (HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f && WolfMouth1.Instance.eat == false)
        {
            body.transform.localPosition = Vector3.MoveTowards(body.transform.localPosition, CurrPos, steptoward);
            
        }
        if (HUDScript.Instance.stressLVL > 25f && HUDScript.Instance.stressLVL <= 50f)
        {
            speed = 2;
            stomping = 0;

        }
        if (HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f && StealthScript.Instance.isHidden == false && PSM.isGrounded == true)
        {
            speed += 0.5f * Time.deltaTime;

        }
        
        if (HUDScript.Instance.stressLVL > 50f && HUDScript.Instance.stressLVL <= 100f)
        {
            if (stomping == 0)
            {
                SoundManager.Instance.blist[5] = true;
            }

            if (stomping <= 6.905f)
            {
                stomping += Time.deltaTime;
            }
            else if (stomping >= 53.808f)
            {
                stomping = 0;
            }

        }






        if (HUDScript.Instance.stressLVL <= 75f)
        {
            speed = startspeed;
        }
    }
}
