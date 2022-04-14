using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern_Decay : MonoBehaviour
{
    float maxIntensity = 0.8f;
    public PlayerStateMachine PSM;
    public Light2D lantern;
    public bool drainOverTime = true;
    public float drainRate, rechargeRate, maxBrightness, minBrightness;

    private void Update()
    {
        LightBoy();
        NightBoy();
    }

    public void LightBoy()
    {
       if(drainOverTime && PSM.isLightOn)
        {
           lantern.intensity = Mathf.Clamp(lantern.intensity, minBrightness, maxBrightness);
            if (lantern.intensity > minBrightness)
            {
                lantern.intensity -= Time.deltaTime * (drainRate / 1000);
            }
            else if(lantern.intensity < minBrightness)
                lantern.intensity = minBrightness;
        }
    }
    public void NightBoy()
    {
        if (drainOverTime && !PSM.isLightOn)
        {
            if (lantern.intensity < maxBrightness)
            {
                lantern.intensity += Time.deltaTime * (rechargeRate / 1000);
            }
            else if (lantern.intensity > maxBrightness)
                lantern.intensity = maxBrightness;
        }
    }
  
}

