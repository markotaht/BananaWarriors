using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    private int greenBanana = 0;
    public int GreenBanana
    {
        get { return greenBanana; }
        set { greenBanana = value; }
    }

    private int yellowBanana = 0;
    public int YellowBanana
    {
        get { return yellowBanana; }
        set { yellowBanana = value; }
    }
	// Use this for initialization
	void Start () {
     //   greenBanana = 0;
     //   yellowbanana = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GreenBanana")
        {
            greenBanana = greenBanana + 1;
        }
        else if(collision.tag == "YellowBanana")
        {
            yellowBanana = yellowBanana + 1;
        }
    }

    public void useBananas()
    {
        //Midagi teha banaanidega
    }
}
