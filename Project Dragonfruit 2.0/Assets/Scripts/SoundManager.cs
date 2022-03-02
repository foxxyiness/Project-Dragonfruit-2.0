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
        for (int i = 0; i < soundsource.Length; i++)
        {
            if (blist[i] == true)
            {
                AS.clip = soundsource[i];
                AS.Play();
                blist[i] = false;
                Debug.Log("Sound " + i + " Played");
            }
        }

    }
}
