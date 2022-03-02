using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObject : MonoBehaviour
{
    public float pointsadded;
    private float timer = 0;
    private float buffertimer = 0;
    public float timedestroy = 2;
    public bool isdestructible;
    private bool activated = false;
    public GameObject parent;
    private bool soundplay;
    public SpriteRenderer spriteRenderer;
    public Sprite destroysprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isdestructible == true)
        {
            if (activated == true)
            {
                timer += Time.deltaTime;
            }
            if (timer >= timedestroy)
            {
                Destroy(parent);
            }
        }
        if (isdestructible == false && activated == true)
        {
            activated = false;
            while (buffertimer <= 2)
            { 
                buffertimer += Time.deltaTime;
            }
        }
    }
    void OnTriggerStay2d(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && isdestructible == false)
        {

        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && isdestructible == true)
        {
            spriteRenderer.sprite = destroysprite;
            HUDScript.Instance.stressLVL += pointsadded;
            if (activated == false)
            { 
                activated = true;
            }
            soundplay = true;
        }
        if (coll.gameObject.tag == "Player" && isdestructible == false)
        {
            soundplay = true;
            HUDScript.Instance.stressLVL += pointsadded;
        }

    }
}
