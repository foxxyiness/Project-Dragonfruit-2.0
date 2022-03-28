using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObject : MonoBehaviour
{
    [Header("General for Trap")]
    public float pointsadded;
    private float timer = 0;
    private float buffertimer = 0;
    public float timedestroy = 2;
    public bool isdestructible;

    private bool activated = false;
    public GameObject parent;
    private bool soundplay;
    [Header("Only for Destructible Traps")]
    public SpriteRenderer spriteRenderer;
    public Sprite destroysprite;
    [Header("Only for Mushroom Traps")]
    public bool isLight;
    public Sprite mushroomOn;
    public Sprite mushroomOff;
    public float lightlength;
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
                Destroy(gameObject);//Ryan changed this
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
        if (isLight)
        {
            if (activated == true)
            {
                timer += Time.deltaTime;
            }
            if (timer >= lightlength)
            {
                activated = false;
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
                SoundManager.Instance.blist[4] = true;
            }
            if (coll.gameObject.tag == "Player" && isdestructible == false) //if the object is a bush
            {
                SoundManager.Instance.blist[3] = true;
                HUDScript.Instance.stressLVL += pointsadded;
            }
            if (coll.gameObject.tag == "Player" && isLight)
            {
                spriteRenderer.sprite = mushroomOn;
                HUDScript.Instance.stressLVL += pointsadded;
                activated = true;
            }

        }
    }
}
