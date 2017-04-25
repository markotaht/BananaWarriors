using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour {

    public void buttonRestart()
    {
        SceneManager.LoadScene("Scenes/Main");
        Time.timeScale = 1;
        PlayerPrefs.SetInt("houses", 0);
        PlayerPrefs.SetInt("warriors", 0);
        PlayerPrefs.SetFloat("Time", 0);
        PlayerPrefs.SetInt("Golden", 0);
        PlayerPrefs.SetInt("bananas", 0);
    }

    public void buttonExit()
    {

        Application.Quit();
      //  Time.timeScale = 1;
    }

}
