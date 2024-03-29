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
        else if(Input.anyKeyDown)
        {
            StartCoroutine(skipAble());
        }
    }

    IEnumerator skipAble()
    {
        skipText.SetActive(true);
        yield return new WaitForSeconds(7);
        skipText.SetActive(false);
    }
}
