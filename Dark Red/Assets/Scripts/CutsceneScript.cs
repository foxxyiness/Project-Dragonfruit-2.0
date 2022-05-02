using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    public VideoPlayer vid;
    public string sceneload;
    
    // Start is called before the first frame update
    void Start()
    {
        vid.loopPointReached += CheckOver;
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneload);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
