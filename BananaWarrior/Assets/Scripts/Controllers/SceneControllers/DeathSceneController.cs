using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour {

    public void buttonRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/Main");
    }

    public void buttonExit()
    {

        Application.Quit();
      //  Time.timeScale = 1;
    }

}
