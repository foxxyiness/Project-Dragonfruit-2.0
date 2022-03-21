using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    public bool zoomout; // tells camera to zoom out
    public bool zoomin; // tells camera to zoom in
    public bool resetcam; //resets camera to 60f
    public CameraZoom Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomout)
            zoomin = false;
        if (zoomin)
            zoomout = false;


        if (zoomout && cam.fieldOfView <= 75f)
        {
            cam.fieldOfView += 0.1f;
        }
        if (zoomout && cam.fieldOfView > 75f)
        {
            zoomout = false;
        }
        if (zoomin && cam.fieldOfView >= 45f)
        {
            cam.fieldOfView -= 0.1f;
        }
        if(zoomin && cam.fieldOfView < 45f)
        {
            zoomin = false;
        }
        if(resetcam)
        {
            zoomout = false;
            zoomin = false;
            if(cam.fieldOfView < 60f)
            {
                if (cam.fieldOfView <= 60f)
                {
                    cam.fieldOfView += 0.1f;

                }
            }
            if (cam.fieldOfView > 60f)
            {
                if (cam.fieldOfView >= 60f)
                {
                    cam.fieldOfView -= 0.1f;
                }
            }
            else if (cam.fieldOfView == 60f)
            {
                cam.fieldOfView = 60f;
                resetcam = false;
            }

        }
    }
}
