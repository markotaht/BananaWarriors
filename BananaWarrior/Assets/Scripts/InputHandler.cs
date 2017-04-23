using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputHandler : MonoBehaviour {

    [SerializeField]
    private MoveController playerController;
    private MoveController currentActor;
    private BananaWarriorAI bananaAI;

    private Event current = new Event();
    private KeyCode currentKey;
    private List<KeyCode> keysDown = new List<KeyCode>();

    private GameObject indicator;
    private Color currentColor;

    bool build = false;
    bool makeKebab = false;
    
    void Start () {
        currentActor = playerController;
    }
	
	
	void Update () {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(point);
        
        if(indicator != null)
        {
            indicator.transform.position = new Vector3(point.x, point.y, 0);
        }
       /* if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/
        //Kuhu klikkisime

        current = new Event();
        Event.PopEvent(current);
        currentKey = ReadKeyCode();
        
        if(currentActor == null || bananaAI != null && !bananaAI.isAlive())
        {
            currentActor = playerController;
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (build || makeKebab)
            {
                if(indicator.tag == "Warrior")
                {
                    indicator.GetComponent<BananaWarriorAI>().changePatrolPlace(point);
                }
                indicator.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
                Vector3 pos = Input.mousePosition;

                build = false;
                makeKebab = false;
                indicator = null;
                return;
            }
            if (hit && hit.gameObject.tag == "Player")
            {
                currentActor = hit.gameObject.GetComponent<MoveController>();
            }
            else if (hit && hit.gameObject.tag == "Warrior")
            {
                currentActor = hit.gameObject.GetComponent<MoveController>();
                bananaAI = hit.gameObject.GetComponent<BananaWarriorAI>();
            }
            else if (currentActor != null)
            {
                if(currentActor.gameObject.tag == "Warrior")
                {
                    bananaAI.changePatrolPlace(point);
                }
                else
                {
                    currentActor.move(point);
                }
            }
        }

        

        if(currentKey == KeyCode.B)
        {
            build = true;
        }
	}

    public void buildHouse()
    {
        build = true;
        indicator = (GameObject)Instantiate(Resources.Load("House/Maja"),
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                 Quaternion.identity);
        currentColor = indicator.GetComponent<Renderer>().material.color;
        indicator.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.4f);
    }

    public void makeBanana()
    {
        makeKebab = true;
        indicator = (GameObject)Instantiate(Resources.Load("Warrior/Warrior"),
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                 Quaternion.identity);
        currentColor = indicator.GetComponent<Renderer>().material.color;
        indicator.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.4f);
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
