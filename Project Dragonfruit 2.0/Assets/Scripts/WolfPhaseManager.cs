using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPhaseManager : MonoBehaviour
{
    public GameObject Phase4WolfEntity;
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

        }
        if (HUDScript.Instance.stressLVL > 25 && HUDScript.Instance.stressLVL >= 50)
        {

        }
        if (HUDScript.Instance.stressLVL > 50 && HUDScript.Instance.stressLVL >= 75)
        {

        }
        if (HUDScript.Instance.stressLVL > 75 && HUDScript.Instance.stressLVL >= 100)
        {
            Instantiate(Phase4WolfEntity, Phase4WolfSpawn.Transform.Position, Quaternion.Identity);
        }

    }
}
