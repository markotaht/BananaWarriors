using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {

    public void buttonRestart()
    {
        Application.LoadLevel("Scenes/Main");
        Time.timeScale = 1;
        PlayerPrefs.SetInt("houses", 0);
        PlayerPrefs.SetInt("warriors", 0);
        PlayerPrefs.SetFloat("Start", Time.time);
        PlayerPrefs.SetInt("Golden", 0);
        PlayerPrefs.SetInt("bananas", 0);
    }

    public void buttonExit()
    {

        Application.Quit();
      //  Time.timeScale = 1;
    }

}
