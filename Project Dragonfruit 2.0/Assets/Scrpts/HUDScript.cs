using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public float stressLVL = 0;
    public float addAmount;
    public static HUDScript Instance;
    public TextMeshProUGUI Display1;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Display1.text = stressLVL.ToString();
    }
}

