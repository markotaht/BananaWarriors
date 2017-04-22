﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    [SerializeField]
    private MoveController currentActor;

    private Event current = new Event();
    private KeyCode currentKey;
    private List<KeyCode> keysDown = new List<KeyCode>();

    bool build = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(point);
        //Kuhu klikkisime

        current = new Event();
        Event.PopEvent(current);
        currentKey = ReadKeyCode();

        if (Input.GetMouseButton(0))
        {
            if (build)
            {
                //Pane maja
                build = false;
                return;
            }
            if (hit && hit.gameObject.tag == "Player")
            {
                currentActor = hit.gameObject.GetComponent<MoveController>();
            }
            else
            {
                currentActor.move(point);
            }
        }

        if(currentKey == KeyCode.B)
        {
            build = true;
        }
	}

    protected KeyCode ReadKeyCode()
    {
        if(current.type == EventType.keyDown && !keysDown.Contains(current.keyCode))
        {
            keysDown.Add(current.keyCode);
            return current.keyCode;
        }else if(current.type == EventType.KeyUp)
        {
            keysDown.Remove(current.keyCode);
        }
        return KeyCode.None;
    }
}
