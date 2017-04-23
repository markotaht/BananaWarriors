using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    private const float GOLDENBANANA_HEAL = 10.0f; // 10%
    private  int kebab_cost = 2; 
    private  int house_cost = 3;


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
	// Use this for initialization
	void Start () {
     //   greenBanana = 0; ärge palun de-kommenteerige neid asju 
     //   yellowbanana = 0;
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

            greenBanana = greenBanana + 1;
        }
        else if (collision.gameObject.tag == "YellowBanana" && YellowBanana < YELLOWBANANA_MAX)
        {

            yellowBanana = yellowBanana + 1;
        }
        else if (collision.gameObject.tag == "GoldenBanana" &&
            ((100.0f - GOLDENBANANA_HEAL) >= this.gameObject.GetComponent<PlayerController>().Life))
        {
            this.gameObject.GetComponent<PlayerController>().Life += GOLDENBANANA_HEAL;
        }
        else
        {
            return;// liiga palju / nõuded pole täidetud
        }
        Destroy(collision.gameObject);

    }
    public bool useGreen(int bananaCountToRemove)
    {
        if(GreenBanana - bananaCountToRemove >= 0)
        {
            GreenBanana -= bananaCountToRemove;
            return true;

        }
        return false;
        //return (GreenBanana -= bananaCountToRemove) >= 0 ? true : false;
    }
    public bool useYellow(int bananaCountToRemove)
    {

        if (YellowBanana - bananaCountToRemove >= 0)
        {
            YellowBanana -= bananaCountToRemove;
            return true;

        }
        return false;
        // return (YellowBanana -= bananaCountToRemove) >= 0? true : false;



        //Midagi teha banaanidega
    }
}
