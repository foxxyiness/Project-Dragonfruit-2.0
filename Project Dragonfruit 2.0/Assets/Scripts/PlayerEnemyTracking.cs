using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyTracking : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public GameObject body;
    public Vector3 CurrPos;
    public Vector3 BodyPos;
    public float speed = 1f;
    float startspeed;
    public bool faceRight = false;
    public PlayerStateMachine PSM;
    public float yoffset = 1f;

    
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
        }
        else
        {
            target = player;
        }
        
        BodyPos = body.transform.position;
        BodyPos.z = body.transform.position.z;
        BodyPos.y += yoffset;
        CurrPos = target.transform.position;
        CurrPos.z = body.transform.position.z;
        if (PSM.isGrounded == true)
            CurrPos.y += yoffset;
        else
            CurrPos.y = body.transform.position.y;
        float steptoward = speed * Time.deltaTime;
        if ((target.transform.localPosition.x - CurrPos.x) < 0 && faceRight)
        {
            faceRight = !faceRight;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        else if ((target.transform.localPosition.x - CurrPos.x) > 0 && !faceRight)
        {
            faceRight = !faceRight;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        if (StealthScript.Instance.isHidden == false && player.GetComponent<PlayerStateMachine>().isGrounded == true)
        { 
            body.transform.localPosition = Vector3.MoveTowards(body.transform.localPosition, CurrPos, steptoward);
        }
        if (HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f && StealthScript.Instance.isHidden == false && PSM.isGrounded == true)
        {
            speed += 0.001f * Time.deltaTime;

        }
        if(HUDScript.Instance.stressLVL <= 75f)
        {
            speed = startspeed;
        }
    }
}
