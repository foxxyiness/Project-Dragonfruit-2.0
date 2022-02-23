using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip[] soundsource;
    public bool[] blist;
    public static SoundManager Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(blist[0])
        {
            AS.clip = soundsource[0];
            AS.Play();
            blist[0] = false;
        }
        if (blist[1])
        {
            AS.clip = soundsource[1];
            AS.Play();
            blist[1] = false;
        }
    }
}
