﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
        Debug.Log("Continue not implemented yet :((");
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