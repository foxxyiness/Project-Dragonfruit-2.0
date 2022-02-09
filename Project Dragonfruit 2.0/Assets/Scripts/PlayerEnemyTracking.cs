using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyTracking : MonoBehaviour
{
    public GameObject player;
    public GameObject body;
    public Vector3 CurrPos;
    public float speed = 1f;
    public bool faceRight = false;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        CurrPos = body.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        CurrPos = player.transform.position;
        CurrPos.z = 0;
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

        body.transform.localPosition = Vector3.MoveTowards(body.transform.localPosition, CurrPos, steptoward);

    }
}
