using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

    private const float GOLDENBANANA_HEAL = 10.0f; // 10%

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLL");
        if(other.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "GreenBanana" )
            {
                if (other.gameObject.GetComponent<InventoryController>().GreenBanana <
                    other.gameObject.GetComponent<InventoryController>().GREENBANANA_MAX)
                {
                    other.gameObject.GetComponent<InventoryController>().GreenBanana++;
                }
                else
                {

                    return; // üle limiidi
                }


            }
            else if(this.gameObject.tag == "YellowBanana")
            {
                if (other.gameObject.GetComponent<InventoryController>().YellowBanana <
                    other.gameObject.GetComponent<InventoryController>().YELLOWBANANA_MAX)
                {
                    other.gameObject.GetComponent<InventoryController>().YellowBanana++;
                }
                else
                {
        
                    return; // üle limiidi
                }


            }
            else if (this.gameObject.tag == "GoldenBanana")
            {

                if(other.gameObject.GetComponent<PlayerController>().Life <= 100.0f - GOLDENBANANA_HEAL)
                {
                    other.gameObject.GetComponent<PlayerController>().Life += GOLDENBANANA_HEAL;
                    
                }
             //   Debug.Log("GoldenBanana korjati üles, aga vist implementatsiooni ei ole et elusid suurendada :/");
            }
            Destroy(this.gameObject);

        }
        //Count


    }

}
