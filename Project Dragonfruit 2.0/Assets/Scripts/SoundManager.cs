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
        //if (blist[0] == true)
        //{
        //    AS.clip = soundsource[0];
        //    AS.Play();
        //    blist[0] = false;
        //    Debug.Log("Sound " + 0 + " Played");
        //}
        //if (blist[1] == true)
        //{
        //    int h = Random.Range(0, 4);
        //    AS.clip = StepBank[h];
        //    AS.Play();
        //    blist[1] = false;
        //    Debug.Log("Step Sound " + 1 + " Played");
        //}
        //if (blist[2] == true)
        //{
        //    AS.clip = soundsource[2];
        //    AS.Play();
        //    blist[2] = false;
        //    Debug.Log("Sound " + 2 + " Played");
        //}
        //if (blist[3] == true)
        //{
        //    AS.clip = soundsource[3];
        //    AS.Play();
        //    blist[3] = false;
        //    Debug.Log("Sound " + 3 + " Played");
        //}
        //if (blist[4] == true)
        //{
        //    AS.clip = soundsource[4];
        //    AS.Play();
        //    blist[4] = false;
        //    Debug.Log("Sound " + 4 + " Played");
        //}
        //if (blist[5] == true)
        //{
        //    AS.clip = soundsource[5];
        //    AS.Play();
        //    blist[5] = false;
        //    Debug.Log("Sound " + 5 + " Played");
        //}
        //if (blist[6] == true)
        //{
        //    AS.clip = soundsource[6];
        //    AS.Play();
        //    blist[6] = false;
        //    Debug.Log("Sound " + 6 + " Played");
        //}
        //if (blist[7] == true)
        //{
        //    AS.clip = soundsource[7];
        //    AS.Play();
        //    blist[7] = false;
        //    Debug.Log("Sound " + 7 + " Played");
        //}
        //if (blist[8] == true)
        //{
        //    AS.clip = soundsource[8];
        //    AS.Play();
        //    blist[8] = false;
        //    Debug.Log("Sound " + 8 + " Played");
        //}
        //if (blist[9] == true)
        //{
        //    AS.clip = soundsource[9];
        //    AS.Play();
        //    blist[9] = false;
        //    Debug.Log("Sound " + 9 + " Played");
        //}

        for (int i = 0; i < soundsource.Length; i++)
        {
            if (blist[i] == true && i == 1)
            {
                h = Random.Range(0, 4);
                AS.PlayOneShot(StepBank[h],1f);
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
