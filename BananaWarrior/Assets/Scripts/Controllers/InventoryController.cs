using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {


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
     //   greenBanana = 0;
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
        // ei tee vist midagi see osa
        if(collision.gameObject.tag == "GreenBanana")
        {
            greenBanana = greenBanana + 1;
        }
        else if(collision.gameObject.tag == "YellowBanana")
        {
            yellowBanana = yellowBanana + 1;
        }
    }

    public void useBananas()
    {
        //Midagi teha banaanidega
    }
}
