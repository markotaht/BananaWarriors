using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class MenuController : MonoBehaviour{

    public bool isOver;
    private Event current = new Event();
    private KeyCode currentKey;
    private List<KeyCode> keysDown = new List<KeyCode>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        current = new Event();
        Event.PopEvent(current);
        currentKey = ReadKeyCode();

        if (currentKey == KeyCode.Escape)
        {
            buttonExit();
        }
    }



    public void buttonContinue()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Scenes/MainMenu");
    }

    public void buttonStartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/Main", LoadSceneMode.Single);
    }

    public void buttonTutorial()
    {
        SceneManager.UnloadSceneAsync("Scenes/MainMenu");
        SceneManager.LoadScene("Scenes/Tutorial", LoadSceneMode.Additive);
    }

    public void buttonExit()
    {
        Application.Quit();
    }

    protected KeyCode ReadKeyCode()
    {
        if (current.type == EventType.keyDown && !keysDown.Contains(current.keyCode))
        {
            keysDown.Add(current.keyCode);
            return current.keyCode;
        }
        else if (current.type == EventType.KeyUp)
        {
            keysDown.Remove(current.keyCode);
        }
        return KeyCode.None;
    }
}
