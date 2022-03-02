using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyTracking : MonoBehaviour
{
    public GameObject player;
    public GameObject body;
    public Vector3 CurrPos;
    public Vector3 BodyPos;
    public float speed = 1f;
    public bool faceRight = false;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        BodyPos = body.transform.position;
        BodyPos.z = 0;
        BodyPos.y = 0;
        CurrPos = player.transform.position;
        CurrPos.z = 0;
        CurrPos.y = 0;
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

        if (WolfMouth1.Instance.caughtplr == false)
        { 
            body.transform.localPosition = Vector3.MoveTowards(body.transform.localPosition, CurrPos, steptoward);
        }

    }
}
