using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MenuManager : MonoBehaviour
{
    public int scenenum;
    public bool loadenabled;
    public GameObject loadscreen;
    public Slider slid;
    public void playGame()
    {
        if (loadenabled == false)
        { 
            SceneManager.LoadScene(scenenum);
        }
        else
        {
            StartCoroutine(LoadAsync());
        }
        Debug.Log("scene load");
    }


    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("quit");
    }
    IEnumerator LoadAsync ()
    {
        AsyncOperation loadop = SceneManager.LoadSceneAsync(scenenum);

        loadscreen.SetActive(true);
        while(!loadop.isDone)
        {
            float progress = Mathf.Clamp01(loadop.progress / .9f);
            slid.value = progress;
            Debug.Log(progress);

            yield return null;
        }
    }
}
