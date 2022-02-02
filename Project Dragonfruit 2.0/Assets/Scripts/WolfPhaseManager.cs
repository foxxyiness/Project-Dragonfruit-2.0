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
        if(HUDScript.Instance.stressLVL >=0 && HUDScript.Instance.stressLVL <= 25)
        {
            Phase1WolfEntity.SetActive(true);
        }
        if (HUDScript.Instance.stressLVL > 25 && HUDScript.Instance.stressLVL >= 50)
        {
            Phase1WolfEntity.SetActive(false);
            Phase2WolfEntity.SetActive(true);
        }
        if (HUDScript.Instance.stressLVL > 50 && HUDScript.Instance.stressLVL >= 75)
        {
            Phase2WolfEntity.SetActive(false);
            Phase3WolfEntity.SetActive(true);
        }
        if (HUDScript.Instance.stressLVL > 75 && HUDScript.Instance.stressLVL >= 100)
        {
            Phase3WolfEntity.SetActive(false);
            Instantiate(Phase4WolfEntity, Phase4WolfSpawn.Transform.Position, Quaternion.Identity);
        }

    }
}
