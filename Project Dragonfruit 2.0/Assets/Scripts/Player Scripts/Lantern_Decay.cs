using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern_Decay : MonoBehaviour
{
    float maxIntensity = 0.8f;
    public PlayerStateMachine PSM;
    public Light2D lantern;
    public WaitForSeconds lanternRegin = new WaitForSeconds(.5f);
    public WaitForSeconds lanternDecay = new WaitForSeconds(1f);
    public static Lantern_Decay instance;
    private void Awake()
    {
        instance = this;
    }

    public void LightBoy()
    {
        StartCoroutine(LightDecay());
    }
    public IEnumerator LightDecay()
    {
        yield return new WaitForSeconds(5);
        while (lantern.intensity >= 0.0f)
        {
            lantern.intensity -= .1f;
            yield return lanternDecay;
        }
        if (lantern.intensity <= 0.0f)
            StartCoroutine(LightRegain());
    }
    public IEnumerator LightRegain()
    {
        yield return new WaitForSeconds(8);
        while(lantern.intensity < maxIntensity)
        {
            lantern.intensity += .1f;
            yield return lanternRegin;
        }
    }
}

