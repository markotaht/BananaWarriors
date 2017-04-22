using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    private int greenBanana = 0;
    private int yellowbanana = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GreenBanana")
        {
            greenBanana += 1;
        }
        else if(collision.tag == "YellowBanana")
        {
            yellowbanana += 1;
        }
    }

    public void useBananas()
    {
        //Midagi teha banaanidega
    }
}
