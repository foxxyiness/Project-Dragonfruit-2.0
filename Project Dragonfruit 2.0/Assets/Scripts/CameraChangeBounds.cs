using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeBounds : MonoBehaviour
{
    SpriteRenderer rend;
    public bool intrig; //set if this trigger zone causes the camera to zoom in
    public bool outtrig; //set if this trigger zone causes the camera to zoom out
    public bool resettrig; //set if this trigger zone causes the camera to reset
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (resettrig)
                CameraZoom.Instance.resetcam = true;
            else if (intrig)
                CameraZoom.Instance.zoomin = true;
            else if (outtrig)
                CameraZoom.Instance.zoomout = true;
        }
    }

}
