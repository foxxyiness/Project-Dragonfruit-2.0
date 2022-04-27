using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPhaseMusic : MonoBehaviour
{
    public AudioSource finalMusic;

    // Update is called once per frame
    void Update()
    {
        if (HUDScript.Instance.stressLVL > 75f)
        {
            finalMusic.Play();
        }
        else
            finalMusic.Pause();
    }
}
