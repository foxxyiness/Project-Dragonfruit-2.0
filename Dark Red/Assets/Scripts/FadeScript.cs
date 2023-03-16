using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public GameObject filter;
    public Image render;
    public bool deathfade;
    public bool winfade;
    public static FadeScript Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        filter.SetActive(true);
        render.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (winfade)
        { 
            deathfade = false; 
            for(float m = 0f;m <1f;m += (0.01f*Time.deltaTime))
            {
                render.color = new Color(1f, 1f, 1f, m);
                Debug.Log("Prog of fade:" + m);
            }
        }
        if (deathfade)
        { 
            winfade = false;
            for (float m = 0f; m < 1f; m += (0.01f* Time.deltaTime))
            {
                render.color = new Color(0f, 0f, 0f, m);
                Debug.Log("Prog of fade:" + m);
            }
        }

    }
}
