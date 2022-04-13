using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuManager : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("scene load");
    }


    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("quit");
    }
}
