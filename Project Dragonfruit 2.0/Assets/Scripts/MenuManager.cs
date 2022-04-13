using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuManager : MonoBehaviour
{
    public int scenenum;
    public void playGame()
    {
        SceneManager.LoadScene(scenenum);
        Debug.Log("scene load");
    }


    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("quit");
    }
}
