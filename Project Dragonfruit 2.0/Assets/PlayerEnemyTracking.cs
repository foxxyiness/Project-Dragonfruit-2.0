using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyTracking : MonoBehaviour
{
    public GameObject player;
    public GameObject body;
    public Vector3 CurrPos;
    public float speed = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        CurrPos = body.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float steptoward = speed * Time.deltaTime;
        body.transform.localPosition = Vector3.MoveTowards(body.transform.localPosition, player.transform.position, steptoward);

    }
}
