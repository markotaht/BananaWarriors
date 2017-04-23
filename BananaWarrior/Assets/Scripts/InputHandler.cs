﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour {

    [SerializeField]
    private MoveController playerController;
    private BananaWarriorAI bananaAI;
    InventoryController player;

    private Event current = new Event();
    private KeyCode currentKey;
    private List<KeyCode> keysDown = new List<KeyCode>();

    private GameObject indicator;
    private Color currentColor;

    bool build = false;
    bool makeKebab = false;

    bool dancing = false;
    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>();
    }
	
	
	void Update () {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(point);
        
        if(indicator != null)
        {
            indicator.transform.position = new Vector3(point.x, point.y, 0);
            indicator.GetComponent<SortingGroup>().sortingOrder = 1000;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //Kuhu klikkisime

        current = new Event();
        Event.PopEvent(current);
        currentKey = ReadKeyCode();
        
        if (Input.GetMouseButtonDown(0))
        {
            if (build || makeKebab)
            {
                if(indicator.tag == "Warrior")
                {
                    indicator.GetComponent<BananaWarriorAI>().changePatrolPlace(point);
                    indicator.GetComponent<MoveController>().enabled = true;
                    indicator.GetComponent<BananaWarriorAI>().setIndicator(false);
                }
                else if (indicator.tag == "House")
                {
                    indicator.GetComponent<HouseController>().setIndicator(false);
                }
                indicator.GetComponent<RenderOrderSetter>().SetOrder();
                indicator.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
                Vector3 pos = Input.mousePosition;

                build = false;
                makeKebab = false;
                indicator = null;
                return;
            }
            else if (playerController != null)
            {
                playerController.move(point);
            }
        }

        

        if(currentKey == KeyCode.B)
        {
            build = true;
        }

        if(currentKey == KeyCode.D)
        {
            dancing = !dancing;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Dance", dancing);
        }

        if(currentKey == KeyCode.Escape)
        {
            Time.timeScale = 0;
            Application.LoadLevelAdditive("Scenes/MainMenu - Copy");
        }
	}

    public void buildHouse()
    {
        if (!player.useGreen(player.HOUSE_COST))
        {
            return;
        }
        build = true;
        indicator = (GameObject)Instantiate(Resources.Load("House/Maja"),
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                 Quaternion.identity);
        currentColor = indicator.GetComponent<Renderer>().material.color;
        indicator.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.4f);
        indicator.GetComponent<SortingGroup>().sortingOrder = 1000;
    }

    public void makeBanana()
    {


        if (!player.useYellow(player.KEBAB_COST))
        {
            return;
        }
        makeKebab = true;
        indicator = (GameObject)Instantiate(Resources.Load("Warrior/Warrior"),
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                 Quaternion.identity);
        currentColor = indicator.GetComponent<Renderer>().material.color;
        indicator.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.4f);
        indicator.GetComponent<MoveController>().enabled = false;
        indicator.GetComponent<SortingGroup>().sortingOrder = 1000;
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
