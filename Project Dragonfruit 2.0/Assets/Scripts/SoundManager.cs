using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip[] soundsource;
    public AudioClip[] StepBank;
    public bool[] blist;
    public static SoundManager Instance;
    int h;
    
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
            if (blist[i] == true && i == 1)
            {
                h = Random.Range(0, 4);
                AS.clip = StepBank[h];
                AS.Play();
                blist[1] = false;
                Debug.Log("Step Sound " + h + " Played");
            }
            if (blist[i] == true && i != 1)
            {
                AS.PlayOneShot(soundsource[i],1f);
                blist[i] = false;
                Debug.Log("Sound " + i + " Played");
            }
        }

    }
}
