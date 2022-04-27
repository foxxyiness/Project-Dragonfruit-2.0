using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;

    void Start()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Tutorial");
        Resume();
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ControlMenu()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    
}
