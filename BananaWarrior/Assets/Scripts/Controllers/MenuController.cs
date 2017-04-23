using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class MenuController : MonoBehaviour{

    public bool isOver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void buttonContinue()
    {
        
        Application.UnloadLevel("Scenes/MainMenu - Copy");
        Time.timeScale = 1;
    }

    public void buttonStartLevel()
    {
        Application.LoadLevel("Scenes/Main");
    }

    public void buttonExit()
    {
        Application.Quit();
    }


}
