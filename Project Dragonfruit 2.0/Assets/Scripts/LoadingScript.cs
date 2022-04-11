using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoadingScript : MonoBehaviour
{
    public string loadscene;
    AsyncOperation load;
    public Slider progbar;
    // Start is called before the first frame update
    void Start()
    {
        load = SceneManager.LoadSceneAsync(loadscene);
    }

    // Update is called once per frame
    void Update()
    {
        progbar.value += Mathf.Clamp01(load.progress);
    }
}
