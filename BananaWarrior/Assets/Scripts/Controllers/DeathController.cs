using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {

    public void buttonRestart()
    {
        Application.LoadLevel("Scenes/Main");
        Time.timeScale = 1;
    }

    public void buttonExit()
    {

        Application.Quit();
      //  Time.timeScale = 1;
    }

}
