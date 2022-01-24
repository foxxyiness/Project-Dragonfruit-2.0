using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void playGame(string TestingScenePrefab)
    {
        SceneManager.LoadScene(TestingScenePrefab);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
