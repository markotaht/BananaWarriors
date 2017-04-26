using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    //private const float GOLDENBANANA_HEAL = 10.0f; // 10%
    private  int kebab_cost = 2; 
    private  int house_cost = 3;
    private int golden_cost = 1;

    private UIController ui;
    public UIController UIController
    {
        get { return ui; }
        set { ui = value; }
    }

    public int KEBAB_COST
    {
        get { return kebab_cost; }
        set { kebab_cost = value; }
    }
    public int HOUSE_COST
    {
        get { return house_cost; }
        set { house_cost = value; }
    }
    public int GOLDEN_COST
    {
        get { return golden_cost; }
        set { golden_cost = value; }
    }


    [SerializeField]
    private int greenBanana = 0;
    public int GreenBanana
    {
        get { return greenBanana; }
        set { greenBanana = value; }
    }
    [SerializeField]
    private int yellowBanana = 0;
    public int YellowBanana
    {
        get { return yellowBanana; }
        set { yellowBanana = value; }
    }
    [SerializeField]
    private int goldenBanana = 0;
    public int GoldenBanana
    {
        get { return goldenBanana; }
        set { goldenBanana = value; }
    }
    // Use this for initialization
    void Start () {
	}

    private const int yellowbanana_max = 10;

    public int YELLOWBANANA_MAX
    {
        get { return yellowbanana_max; }
    
    }

    private const int greenbanana_max = 10;

    public int GREENBANANA_MAX
    {
        get { return greenbanana_max;  }
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GreenBanana" && GreenBanana < GREENBANANA_MAX)
        {
            UIController.updateGreenBanana(++greenBanana, GREENBANANA_MAX, greenBanana >= house_cost);
        }
        else if (collision.gameObject.tag == "YellowBanana" && YellowBanana < YELLOWBANANA_MAX)
        {
            UIController.updateYellowBanana(++yellowBanana, YELLOWBANANA_MAX, yellowBanana >= kebab_cost);
        }
        else if (collision.gameObject.tag == "GoldenBanana")
        {
            UIController.updateGoldenBanana(++goldenBanana, goldenBanana >= golden_cost);
            PlayerPrefs.SetInt("Golden", PlayerPrefs.GetInt("Golden") + 1);
        }
        else
        {
            return;// liiga palju / nõuded pole täidetud
        }
        PlayerPrefs.SetInt("bananas", PlayerPrefs.GetInt("bananas") + 1);
        Destroy(collision.gameObject);

    }

    public bool useGreen(int bananaCountToRemove)
    {
        if(GreenBanana - bananaCountToRemove >= 0)
        {
            GreenBanana -= bananaCountToRemove;
            ui.updateGreenBanana(greenBanana, GREENBANANA_MAX, greenBanana >= house_cost);
            return true;
        }
        return false;
    }
    public bool useYellow(int bananaCountToRemove)
    {

        if (YellowBanana - bananaCountToRemove >= 0)
        {
            YellowBanana -= bananaCountToRemove;
            ui.updateYellowBanana(YellowBanana, YELLOWBANANA_MAX, yellowBanana >= kebab_cost);
            return true;

        }
        return false;
    }

    public bool useGolden(int bananaCountToRemove)
    {
        if (GoldenBanana - bananaCountToRemove >= 0)
        {
            GoldenBanana -= bananaCountToRemove;
            ui.updateGoldenBanana(goldenBanana, goldenBanana >= golden_cost);
            return true;

        }
        return false;
    }
}
