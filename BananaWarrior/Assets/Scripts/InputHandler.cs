using System.Collections;
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
    float bananaHeal = 10;

    bool dancing = false;
    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>();
        PlayerPrefs.SetInt("houses", 0);
        PlayerPrefs.SetInt("warriors", 0);
        PlayerPrefs.SetFloat("Time", 0);
        PlayerPrefs.SetInt("Golden", 0);
        PlayerPrefs.SetInt("bananas", 0);
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
                    PlayerPrefs.SetInt("warriors", PlayerPrefs.GetInt("warriors") + 1);
                    AudioController.Play("banana");
                }
                else if (indicator.tag == "House")
                {
                    indicator.GetComponent<HouseController>().setIndicator(false);
                    PlayerPrefs.SetInt("houses", PlayerPrefs.GetInt("houses") + 1);
                    AudioController.Play("banana");
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

        if (Input.GetMouseButton(1))
        {
            DestroyObject(indicator);
            indicator = null;
            if (build)
            { 
                build = false;
                player.useGreen(-player.HOUSE_COST);
            }
            if (makeKebab)
            {
                player.useYellow(-player.KEBAB_COST);
                makeKebab = false;
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
            SceneManager.LoadScene("Scenes/MainMenu", LoadSceneMode.Additive);
        //    Application.LoadLevelAdditive("Scenes/MainMenu - Copy");
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

        EventSystem.current.SetSelectedGameObject(null);
        if (!player.useYellow(player.KEBAB_COST))
        {
            return;
        }
        makeKebab = true;
        indicator = (GameObject)Instantiate(Resources.Load("Warrior/Warrior 1"),
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                 Quaternion.identity);
        currentColor = indicator.GetComponent<Renderer>().material.color;
        indicator.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.4f);
        indicator.GetComponent<MoveController>().enabled = false;
        indicator.GetComponent<SortingGroup>().sortingOrder = 1000;
    }

    public void heal()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (player.useGolden(player.GOLDEN_COST))
        {
            player.gameObject.GetComponent<PlayerController>().Life += bananaHeal;
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
