using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern_Decay : MonoBehaviour
{
    float maxIntensity = 0.8f;
    public PlayerStateMachine PSM;
    public Light2D lantern;
    public GameObject lanternText;
    private bool drainOverTime = true;
    private float drainRate, rechargeRate, maxBrightness, minBrightness;
    private void Start()
    {
        drainRate = 50f;
        rechargeRate = 100.0f;
        maxBrightness = 0.8f;
        minBrightness = 0.01f;
    }

    private void Update()
    {
        LightBoy();
        NightBoy();
    }

    private void LightBoy()
    {
       if(drainOverTime && PSM.isLightOn)
        {
           lantern.intensity = Mathf.Clamp(lantern.intensity, minBrightness, maxBrightness);
            if (lantern.intensity > minBrightness)
            {
                lantern.intensity -= Time.deltaTime * (drainRate / 1000);
            }
            else if(lantern.intensity <= minBrightness)
            {
                lantern.intensity = minBrightness;
                StartCoroutine(suggestedLight());
            }
                
                
        }
    }
    private void NightBoy()
    {
        lanternText.SetActive(false);
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

    IEnumerator suggestedLight()
    {
        yield return new WaitForSeconds(5);
        lanternText.SetActive(true);
        if (!PSM.isLightOn)
        {
            StopCoroutine(suggestedLight());
            NightBoy();
        }
    
    }

  
}

