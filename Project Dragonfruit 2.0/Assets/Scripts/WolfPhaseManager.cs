using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPhaseManager : MonoBehaviour
{
    public GameObject Phase1WolfEntity;
    public GameObject Phase2WolfEntity;
    public GameObject Phase4WolfEntity;
    public GameObject Phase3WolfEntity;
    public GameObject Phase4WolfSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HUDScript.Instance.stressLVL >=0f && HUDScript.Instance.stressLVL <= 25f)
        {
            //Phase1WolfEntity.SetActive(true);
            StealthScript.Instance.resetval = 2f;

        }
        if (HUDScript.Instance.stressLVL > 25f && HUDScript.Instance.stressLVL <= 50f)
        {
            //Phase1WolfEntity.SetActive(false);
            //Phase2WolfEntity.SetActive(true);
            StealthScript.Instance.resetval = 1.5f;
        }
        if (HUDScript.Instance.stressLVL > 50f && HUDScript.Instance.stressLVL <= 75f)
        {
            //Phase2WolfEntity.SetActive(false);
            //Phase3WolfEntity.SetActive(true);
            StealthScript.Instance.resetval = 1f;
        }
        if (HUDScript.Instance.stressLVL > 75f && HUDScript.Instance.stressLVL <= 100f)
        {
            //Phase3WolfEntity.SetActive(false);
            //Instantiate(Phase4WolfEntity, Phase4WolfSpawn.transform.position, Quaternion.identity);
            StealthScript.Instance.resetval = 0.5f;
        }

    }
}
