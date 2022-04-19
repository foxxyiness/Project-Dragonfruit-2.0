using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScript : MonoBehaviour
{

    public GameObject skipText;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            skipText.SetActive(true);
        }
    }
}
